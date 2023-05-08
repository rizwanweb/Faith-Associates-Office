CREATE PROCEDURE [dbo].[usp_PidPayordersDeleteByPidID]
(
	@PidID	int
)
as
DELETE FROM [dbo].[PidPayorders]
      WHERE PidID = @PidID