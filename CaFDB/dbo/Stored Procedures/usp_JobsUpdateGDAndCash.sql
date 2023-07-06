CREATE PROCEDURE [dbo].[usp_JobsUpdateGDAndCash]
(
	 @JobID	INT
	,@GD	nvarchar(100)
	,@GDDate	date
	,@Cash	nvarchar(100)
	,@CashDate	date
)
AS
UPDATE [dbo].[Jobs]
   SET [GD] = @GD
      ,[GDDate] = @GDDate
      ,[Cash] = @Cash
      ,[CashDate] = @CashDate
 WHERE JobID = @JobID



