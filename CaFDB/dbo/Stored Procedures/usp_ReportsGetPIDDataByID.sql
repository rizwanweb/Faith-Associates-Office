
CREATE PROCEDURE [dbo].[usp_ReportsGetPIDDataByID]
(
	@PidID	INT
)
AS
SELECT Concat([Pids].[PidNo], '/',  YEAR([Pids].PidDate)) AS 'PidNo'
      ,CONVERT(VARCHAR, [Pids].[PidDate], 103) AS 'PidDate'
      ,[Clients].[ClientName]
	  ,[Clients].[ContactPerson]
	  ,CONCAT('A/c ',[Clients].ClientName, ' NTN # ', [Clients].NTN) as 'NTN'
	  ,[Cities].CityName
      ,[Pids].[LC]
      ,[Pids].[LCDate]
      ,[Items].[ItemName]
      ,[Pids].[ItemDetail]
	  ,CASE
		WHEN [Pids].[Containers] > 0
			THEN Concat([Pids].[Containers], ' X ', [Pids].[Size], 'CONTAINERS')     
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
      ,[Pids].[DeliveryCharges]
      ,[Wharfage]
      ,[Pids].[ContainerDeposit]
      ,[Pids].[LoloCharges]
      ,[Pids].[Rent]
      ,[Pids].[PSQCA1]
      ,[Pids].[PSQCA2]
      ,[Pids].[Terminal]
      ,[Pids].[ShippingLine]
      ,[Pids].[Lolo]
	  ,CONCAT([Terminals].ShortName, ' WHARFAGE') as 'TerminalShortName'
	  ,[Terminals].TerminalName
	  ,[ShippingLines].[ShippingLineName]
	  ,[LOLOs].LoloName
  FROM [dbo].[Pids]
  INNER JOIN Clients on Pids.Client = Clients.ClientID
  INNER JOIN Items ON Items.ItemID = Pids.Item
  INNER JOIN Cities ON Clients.City = Cities.CityID
  INNER JOIN Terminals ON Pids.Terminal = Terminals.TerminalID
  INNER JOIN ShippingLines ON Pids.ShippingLine = ShippingLines.ShippingLineID
  INNER JOIN LOLOs ON Pids.Lolo = LOLOs.LoloID
  WHERE PidID = @PidID



