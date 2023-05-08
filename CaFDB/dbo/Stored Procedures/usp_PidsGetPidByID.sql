CREATE PROCEDURE [dbo].[usp_PidsGetPidByID]
(
	@PidID INT
)
AS
	BEGIN
		SELECT [PidID]
			  ,[PidNo]
			  ,[PidDate]
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
			  ,[CustomDuty]
			  ,[CustomDutyType]
			  ,[CustomDutyRate]
			  ,[AddCustomDuty]
			  ,[AddCustomDutyType]
			  ,[AddCustomDutyRate]
			  ,[SalesTax]
			  ,[SalesTaxType]
			  ,[SalesTaxRate]
			  ,[IncomeTax]
			  ,[IncomeTaxType]
			  ,[IncomeTaxRate]
			  ,[Cess]
			  ,[CessType]
			  ,[CessRate]
			  ,[RD]
			  ,[RDType]
			  ,[RDRate]
			  ,[TotalDuty]

			  ,[Terminal]
			  ,[ShippingLine]
			  ,[Lolo]

			  ,[Clients].[ContactPerson]
			  ,[Clients].[Address]
		  FROM [dbo].[Pids]
		  INNER JOIN Clients ON Clients.ClientID = Pids.Client
		  WHERE PidID = @PidID
	END


