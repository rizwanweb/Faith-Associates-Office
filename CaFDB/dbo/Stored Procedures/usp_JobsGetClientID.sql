CREATE PROCEDURE usp_JobsGetClientID
(
	@JobID	int
)
AS
SELECT client from jobs where JobID = @JobID