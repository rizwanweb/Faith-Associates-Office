CREATE PROCEDURE [dbo].[usp_ReportsGetNewPidDataByID]
(
	@PidID	INT
)
AS
SELECT Concat([Pids].[PidNo], '/',  YEAR([Pids].PidDate)) AS 'JobNo'
      ,CONVERT(VARCHAR, [Pids].[PidDate], 103) AS 'JobDate'
      ,[Clients].[ClientName]
	  ,[Clients].[ContactPerson]
	  ,CONCAT('A/c ',[Clients].ClientName, ' NTN # ', [Clients].NTN) as 'NTN'
	  ,[Cities].CityName
	  ,[Pids].[LC]
	  ,CASE 
		WHEN [Pids].[LC] IS NULL OR [Pids].[LC] = ''
			THEN ''
		ELSE
			[Pids].[LCDate]
	   END AS 'LCDate'      
      ,[Items].[ItemName]
      ,[Pids].[ItemDetail]
	  ,CASE
		WHEN [Pids].[Containers] > 0
			THEN Concat([Pids].[Containers], ' X ', [Pids].[Size], ' CONTAINERS')     
		ELSE
			[Pids].[Packages]
		END AS 'Containers'
	  ,[Pids].[Packages]
      ,[Pids].[Vessel]
      ,[Pids].[BL]
      ,[Pids].[BLDate]
	  ,CONCAT([Pids].[IGM], '/',YEAR([Pids].[IGMDate]), ' DATED ', CONVERT(VARCHAR, [Pids].[IGMDate], 103)) AS 'IGM'
	  ,CONVERT(VARCHAR, [Pids].[IGMDate], 103) AS 'IGMDate'
      ,[Pids].[IndexNo]
      ,[Pids].[Quantity]
      ,[Pids].[InvoiceValueUSD]
      ,[Pids].[ExchangeRate]
      ,[Pids].[ValueInPKR]
      ,[Pids].[Insurance]
      ,[Pids].[LandingCharges]
      ,[Pids].[ImportValuePKR]
      ,[Pids].[CustomDuty]
      ,[Pids].[CustomDutyType]
      ,[Pids].[CustomDutyRate]
      ,[Pids].[AddCustomDuty]
      ,[Pids].[AddCustomDutyType]
      ,[Pids].[AddCustomDutyRate]
      ,[Pids].[SalesTax]
      ,[Pids].[SalesTaxType]
      ,[Pids].[SalesTaxRate]
      ,[Pids].[IncomeTax]
      ,[Pids].[IncomeTaxType]
      ,[Pids].[IncomeTaxRate]
      ,[Pids].[Cess]
      ,[Pids].[CessType]
      ,[Pids].[CessRate]
      ,[Pids].[RD]
      ,[Pids].[RDType]
      ,[Pids].[RDRate]
      ,[Pids].[TotalDuty]
      ,[Pids].[Terminal]
      ,[Pids].[ShippingLine]
      ,[Pids].[Lolo]

	  ,jp.Particular
	  ,jp.Amount
	  ,jp.Detail
  FROM [dbo].[Pids]
  INNER JOIN Clients on Pids.Client = Clients.ClientID
  INNER JOIN Items ON Items.ItemID = Pids.Item
  INNER JOIN Cities ON Clients.City = Cities.CityID
  RIGHT JOIN PidPayorders jp On [Pids].PidID = jp.PidID
  WHERE [Pids].PidID = @PidID
  AND jp.Amount > 0