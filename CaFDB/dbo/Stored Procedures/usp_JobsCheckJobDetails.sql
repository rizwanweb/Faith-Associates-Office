CREATE PROCEDURE [dbo].[usp_JobsCheckJobDetails]
(
	@JobNo int
	,@Year int
)
AS
	BEGIN

		DECLARE @IfJobExist BIT
		SET @IfJobExist = 0

		IF EXISTS (SELECT '#' FROM [dbo].[Jobs] WHERE [JobNo] = @JobNo AND YEAR([JobDate]) = @YEAR)
			BEGIN
				SET @IfJobExist = 1
			END
		SELECT @IfJobExist AS '@IfJobExist'


	END