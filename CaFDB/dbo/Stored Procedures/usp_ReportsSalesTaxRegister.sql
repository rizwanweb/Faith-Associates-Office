CREATE PROCEDURE [dbo].[usp_ReportsSalesTaxRegister]
(
	@StartDate	date
	,@EndDate	date
)
AS
SELECT st.[SalesTaxNo]
      ,Convert(varchar, st.[STDate], 103) as STDate
      ,b.[BillNo] AS 'BillNo'
	  ,st.SalesTaxNo
      ,st.[Rate]
      ,st.[SalesTax]
	  ,b.ServiceCharges
	  ,c.ClientName
	  ,c.GST
	  ,c.Address
	  ,ct.CityName
	  ,CASE
		WHEN [j].[Containers] IS NULL OR j.Containers = ''
			THEN j.Packages
		ELSE
			Concat([j].[Containers], 'X', [j].[Size], ' CONT STC ', j.Packages)
	   END As Packages

	  ,Convert(varchar, @StartDate, 103) AS 'StartDate'
	  ,Convert(varchar, @EndDate, 103) AS 'EndDate'

	  ,i.ItemName
	  ,i.HSCode

  FROM [dbo].[SalesTaxInvoice] st
  INNER JOIN Bills b on b.BillID = st.BillID
  INNER JOIN Jobs j ON b.JobID = j.JobID
  INNER JOIN Clients c ON c.ClientID = j.Client
  INNER JOIN Cities ct on c.City = ct.CityID
  INNER JOIN Items i on j.Item = i.ItemID

  WHERE STDate BETWEEN @StartDate AND @EndDate