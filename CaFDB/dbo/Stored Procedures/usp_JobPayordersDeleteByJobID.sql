CREATE PROCEDURE [dbo].[usp_JobPayordersDeleteByJobID]
(
	@JobID	int
)
as
DELETE FROM [dbo].[JobPayorders]
      WHERE JobID = @JobID