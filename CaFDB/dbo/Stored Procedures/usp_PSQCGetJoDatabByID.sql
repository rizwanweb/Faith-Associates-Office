CREATE PROCEDURE [dbo].[usp_PSQCGetJoDatabByID]
(
	@JobID INT
)
AS
	BEGIN
		SELECT [JobID]
			  ,[JobNo]			  
			  ,[Client]
			  ,[Item]
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
			  ,[ImportValuePKR]

			  ,[Terminal]
			  ,[ShippingLine]
			  ,[Lolo]

			  ,[Clients].[ClientName]
			  ,[Clients].[ContactPerson]
			  ,[Clients].[Address]
			  ,[Clients].Phone
			  --,[Clients].Fax
			  --,[Clients].StandAddress

			  ,[Items].[ItemName]
			  ,[Items].[HSCode]
			  ,[Terminals].TerminalName
		  FROM [dbo].[Jobs]
		  INNER JOIN Clients ON Clients.ClientID = Jobs.Client
		  INNER JOIN Items ON Items.ItemID = Jobs.Item
		  INNER JOIN Terminals ON Terminals.TerminalID = Jobs.Terminal
		  WHERE JobID = @JobID
	END