CREATE PROCEDURE [dbo].[usp_PidsUpdateGDAndCash]
(
	 @PidID	INT
	,@GD	nvarchar(100)
	,@GDDate	date
	,@Cash	nvarchar(100)
	,@CashDate	date
)
AS
UPDATE [dbo].[Pids]
   SET [GD] = @GD
      ,[GDDate] = @GDDate
      ,[Cash] = @Cash
      ,[CashDate] = @CashDate
 WHERE PidID = @PidID



