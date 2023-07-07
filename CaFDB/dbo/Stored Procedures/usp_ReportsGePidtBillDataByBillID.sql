CREATE PROCEDURE [dbo].[usp_ReportsGePidtBillDataByBillID]
(
	@BillID	INT
)
AS
BEGIN
	SELECT  j.PidNo
		   ,CASE
				WHEN [j].[Containers] > 0
				THEN Concat([j].[Containers], ' X ', [j].[Size], 'CONT STC ', j.Packages)     
				ELSE
				[j].[Packages]
			END AS 'Packages'
		   ,j.IGM
		   ,CONVERT(varchar, j.IGMDate, 103) AS 'IGMDate'
		   ,j.IndexNo
		   ,j.Vessel
		   ,j.BL
		   ,CONVERT(varchar, j.BLDate, 103) AS 'BLDate'		   
		   ,j.LC
		   ,CASE
				WHEN j.LC IS NULL
				THEN ''
				ELSE CONVERT(varchar, j.LCDate, 103)
			END AS 'LCDate'
		   --,CONVERT(varchar, j.LCDate, 103) AS 'LCDate'
		   ,j.ImportValuePKR
		   ,j.GD
		   ,CONVERT(varchar, j.GDDate, 103) AS 'GDDate' 
		   ,j.Cash
		   ,CONVERT(varchar, j.CashDate, 103) AS 'CashDate'

		   ,b.BillNo
		   ,CONVERT(varchar, b.BillDate, 103) AS 'BillDate'
		   ,b.Total
		   ,b.Note		   
		   ,c.ClientName
		   ,Concat(c.Address, ',',  Cities.CityName) AS 'Address'
		   ,c.[Address]
		   ,c.GST

		   ,i.ItemName

		   ,Cities.CityName
		   ,Terminals.ShortName

		   ,CONCAT(d.[Particulars], ' ', d.[ReceiptNo]) AS 'Particulars'
		   ,d.ByYou
		   ,d.ByUs

		   
		   
	FROM PidBills b
	INNER JOIN Pids j ON b.PidID = j.PidID
	INNER JOIN Clients c ON c.ClientID = j.Client
	INNER JOIN Items i ON i.ItemID = j.Item
	INNER JOIN Cities ON Cities.CityID = c.City
	INNER JOIN Terminals ON Terminals.TerminalID = j.Terminal
	RIGHT JOIN PidBillDetails d ON b.BillID = d.BillID
	
	WHERE b.BillID = @BillID
	AND (d.ByYou > 0 OR d.ByUs > 0)
END
