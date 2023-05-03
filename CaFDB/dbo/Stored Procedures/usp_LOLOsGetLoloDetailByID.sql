CREATE PROCEDURE [dbo].[usp_LOLOsGetLoloDetailByID]
(
	@LoloID INT	
)
AS

	BEGIN
		SELECT [LoloID]
			  ,[LoloName]
			  ,[ShortName]
			  ,[Phone]
			  ,[Email]

		  FROM [dbo].[LOLOs]
		  WHERE [LoloID] = @LoloID
	END


