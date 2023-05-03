CREATE PROCEDURE usp_ClientsDeleteClient
(
	@ClientID INT
)
AS
	BEGIN
		DELETE FROM [dbo].[Clients]
			  WHERE [ClientID] = @ClientID
	END


