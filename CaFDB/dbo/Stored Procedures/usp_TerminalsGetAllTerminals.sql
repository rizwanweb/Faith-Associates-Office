CREATE PROCEDURE usp_TerminalsGetAllTerminals
AS
	BEGIN
		SELECT [TerminalID]
		  ,[TerminalName]
		  ,[ShortName]
		  ,[Phone]
		  ,[Email]
		FROM [dbo].[Terminals]
	END



