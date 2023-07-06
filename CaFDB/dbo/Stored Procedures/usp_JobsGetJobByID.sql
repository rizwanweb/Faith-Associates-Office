CREATE PROCEDURE [dbo].[usp_JobsGetJobByID]
(
	@JobID INT
)
AS
	BEGIN
		SELECT [JobID]
			  ,[JobNo]
			  ,[JobDate]
			  ,[Client]
			  ,[LC]
			  ,[LCDate]
			  ,[Item]
			  ,[ItemDetail]
			  ,[Containers]
			  ,[Size]
			  ,[Packages]
			  ,[Vessel]
			  ,[BL]
			  ,[BLDate]
			  ,[IGM]
			  ,[IGMDate]
			  ,[IndexNo]
			  ,[Quantity]
			  ,[InvoiceValueUSD]
			  ,[ExchangeRate]
			  ,[ValueInPKR]
			  ,[Insurance]
			  ,[LandingCharges]
			  ,[ImportValuePKR]
			  ,Jobs.[CustomDuty]
			  ,Jobs.[CustomDutyType]
			  ,Jobs.[CustomDutyRate]
			  ,Jobs.[AddCustomDuty]
			  ,Jobs.[AddCustomDutyType]
			  ,[AddCustomDutyRate]
			  ,Jobs.[SalesTax]
			  ,[SalesTaxType]
			  ,[SalesTaxRate]
			  ,Jobs.[IncomeTax]
			  ,[IncomeTaxType]
			  ,[IncomeTaxRate]
			  ,Jobs.[Cess]
			  ,Jobs.[CessType]
			  ,[CessRate]
			  ,Jobs.[RD]
			  ,Jobs.[RDType]
			  ,[RDRate]
			  ,[TotalDuty]

			  ,[Terminal]
			  ,[ShippingLine]
			  ,[Lolo]

			  ,[Clients].[ClientName]
			  ,[Clients].[ContactPerson]
			  ,[Clients].[Address]
			  ,[Clients].Phone
			  ,[Clients].Mobile
			  ,[Clients].Email
			  ,[Clients].NTN

			  ,[Items].[ItemName]
			  ,[Items].HSCode
		  FROM [dbo].[Jobs]
		  INNER JOIN Clients ON Clients.ClientID = Jobs.Client
		  INNER JOIN Items ON Items.ItemID = Jobs.Item
		  WHERE JobID = @JobID
	END


