CREATE PROCEDURE [dbo].[usp_PidsDeletePid]
(
	@PidID	INT
)
AS
	BEGIN
		DELETE FROM [dbo].[Pids]
			  WHERE [PidID] = @PidID
	END
