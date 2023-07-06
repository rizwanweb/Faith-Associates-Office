CREATE PROCEDURE [dbo].[usp_ClientTypeGetClientType]
AS
	BEGIN
		SELECT [TypeID]
			  ,[Description]
		  FROM [dbo].[ClientTypes]
	END



