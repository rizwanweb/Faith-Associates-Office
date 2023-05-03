CREATE PROCEDURE usp_TerminalsDeleteTerminal
(
	@TerminalID	INT
)
AS
DELETE FROM [dbo].[Terminals]
      WHERE TerminalID = @TerminalID

