CREATE PROCEDURE [dbo].[usp_ClientGetLastClientID]

AS
BEGIN
	SELECT TOP 1 ClientID from Clients ORDER BY ClientID DESC
END