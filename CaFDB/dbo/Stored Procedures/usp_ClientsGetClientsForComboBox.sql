CREATE PROCEDURE [dbo].[usp_ClientsGetClientsForComboBox]
AS
	BEGIN
		SELECT [ClientID]
			  ,[ClientName]
		  FROM [dbo].[Clients]
		  ORDER BY ClientName ASC
	END
