CREATE PROCEDURE [dbo].[usp_ReportsGetJobDataByID]
(
	@JobID	INT
)
AS
SELECT Concat([Jobs].[JobNo], '/',  YEAR([jobs].JobDate)) AS 'JobNo'
      ,CONVERT(VARCHAR, [Jobs].[JobDate], 103) AS 'JobDate'
      ,[Clients].[ClientName]
	  ,[Clients].[ContactPerson]
	  ,CONCAT('A/c ',[Clients].ClientName, ' NTN # ', [Clients].NTN) as 'NTN'
	  ,[Cities].CityName
	  ,[Jobs].[LC]
	  ,CASE 
		WHEN [Jobs].[LC] IS NULL OR [Jobs].[LC] = ''
			THEN ''
		ELSE
			[Jobs].[LCDate]
	   END AS 'LCDate'      
      ,[Items].[ItemName]
      ,[Jobs].[ItemDetail]
	  ,CASE
		WHEN [Jobs].[Containers] > 0
			THEN Concat([Jobs].[Containers], ' X ', [Jobs].[Size], ' CONTAINERS')     
		ELSE
			[Jobs].[Packages]
		END AS 'Containers'
	  ,[Jobs].[Packages]
      ,[Jobs].[Vessel]
      ,[Jobs].[BL]
      ,[Jobs].[BLDate]
	  ,CONCAT([Jobs].[IGM], '/',YEAR([Jobs].[IGMDate]), ' DATED ', CONVERT(VARCHAR, [Jobs].[IGMDate], 103)) AS 'IGM'
	  ,CONVERT(VARCHAR, [Jobs].[IGMDate], 103) AS 'IGMDate'
      ,[Jobs].[IndexNo]
      ,[Jobs].[Quantity]
      ,[Jobs].[InvoiceValueUSD]
      ,[Jobs].[ExchangeRate]
      ,[Jobs].[ValueInPKR]
      ,[Jobs].[Insurance]
      ,[Jobs].[LandingCharges]
      ,[Jobs].[ImportValuePKR]
      ,[Jobs].[CustomDuty]
      ,[Jobs].[CustomDutyType]
      ,[Jobs].[CustomDutyRate]
      ,[Jobs].[AddCustomDuty]
      ,[Jobs].[AddCustomDutyType]
      ,[Jobs].[AddCustomDutyRate]
      ,[Jobs].[SalesTax]
      ,[Jobs].[SalesTaxType]
      ,[Jobs].[SalesTaxRate]
      ,[Jobs].[IncomeTax]
      ,[Jobs].[IncomeTaxType]
      ,[Jobs].[IncomeTaxRate]
      ,[Jobs].[Cess]
      ,[Jobs].[CessType]
      ,[Jobs].[CessRate]
      ,[Jobs].[RD]
      ,[Jobs].[RDType]
      ,[Jobs].[RDRate]
      ,[Jobs].[TotalDuty]
      ,[Jobs].[Terminal]
      ,[Jobs].[ShippingLine]
      ,[Jobs].[Lolo]

	  ,jp.Particular
	  ,jp.Amount
	  ,jp.Detail
  FROM [dbo].[Jobs]
  INNER JOIN Clients on Jobs.Client = Clients.ClientID
  INNER JOIN Items ON Items.ItemID = Jobs.Item
  INNER JOIN Cities ON Clients.City = Cities.CityID
  RIGHT JOIN JobPayorders jp On [Jobs].JobID = jp.JobID
  WHERE [Jobs].JobID = @JobID
  AND jp.Amount > 0



