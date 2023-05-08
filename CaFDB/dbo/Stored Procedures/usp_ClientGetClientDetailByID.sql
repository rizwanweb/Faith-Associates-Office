CREATE PROCEDURE [dbo].[usp_ClientGetClientDetailByID]
(
	@ClientID INT	
)
AS

	BEGIN
		SELECT [ClientID]
			  ,[ClientName]
			  ,[ContactPerson]
			  ,[Phone]
			  ,[Mobile]
			  ,[Email]
			  ,[NTN]
			  ,[GST]
			  ,[Address]
			  ,[City]
			  ,[ClientType]
			  ,[StandAddress]
			  ,[Fax]
			  ,[CNIC]
			  ,[Designation]
			  ,c.CityName
		  FROM [dbo].[Clients]
		  INNER JOIN Cities c on City = c.CityID
		  WHERE [ClientID] = @ClientID
	END


