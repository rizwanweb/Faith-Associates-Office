CREATE PROCEDURE usp_JobsDeleteJob
(
	@JobID	INT
)
AS
	BEGIN
		DELETE FROM [dbo].[Jobs]
			  WHERE [JobID] = @JobID
	END
