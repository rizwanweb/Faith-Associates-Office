CREATE PROCEDURE [dbo].[usp_TerminalsDeleteTerminal]
(
	@TerminalID	INT
)
AS
DELETE FROM [dbo].[Terminals]
      WHERE TerminalID = @TerminalID

