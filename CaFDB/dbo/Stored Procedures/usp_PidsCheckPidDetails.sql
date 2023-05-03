
Create PROCEDURE [dbo].[usp_PidsCheckPidDetails]
(
	@PidNo int
	,@Year int
)
AS
	BEGIN

		DECLARE @IfPidExist BIT
		SET @IfPidExist = 0

		IF EXISTS (SELECT '#' FROM [dbo].[Pids] WHERE [PidNo] = @PidNo AND YEAR([PidDate]) = @YEAR)
			BEGIN
				SET @IfPidExist = 1
			END
		SELECT @IfPidExist AS '@IfPidExist'


	END