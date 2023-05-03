CREATE PROCEDURE [dbo].[usp_ClientGetAllClients]
AS
	BEGIN
		SELECT [ClientID]
			  ,[ClientName] AS 'Client Name'
			  ,[ContactPerson] AS 'Contact Person'
			  ,[Phone] AS 'Phone'
			  ,[Mobile] AS 'Mobile'
			  ,[Email] AS 'Email'
		  FROM [dbo].[Clients]
		  ORDER BY ClientName ASC
	  END
