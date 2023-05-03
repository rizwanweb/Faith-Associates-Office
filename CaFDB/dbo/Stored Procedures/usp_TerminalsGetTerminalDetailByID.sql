CREATE PROCEDURE [dbo].[usp_TerminalsGetTerminalDetailByID]
(
	@TerminalID INT	
)
AS

	BEGIN
		SELECT [TerminalID]
			  ,[TerminalName]
			  ,[ShortName]
			  ,[Phone]
			  ,[Email]

		  FROM [dbo].[Terminals]
		  WHERE [TerminalID] = @TerminalID
	END