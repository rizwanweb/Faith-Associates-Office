CREATE PROCEDURE [dbo].[usp_PidsGetClientID]
(
	@PIDID	int
)
AS
SELECT client from Pids where PidID = @PIDID