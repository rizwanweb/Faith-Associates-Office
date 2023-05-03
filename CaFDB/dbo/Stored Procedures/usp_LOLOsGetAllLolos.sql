CREATE PROCEDURE usp_LOLOsGetAllLolos
AS
	BEGIN
		SELECT [LoloID]
		  ,[LoloName]
		  ,[ShortName]
		  ,[Phone]
		  ,[Email]
		FROM [dbo].[LOLOs]
	END



