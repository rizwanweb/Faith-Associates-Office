CREATE PROCEDURE [dbo].[usp_JobPayorderUpdatePayorder]
(
			@PayorderID INT
		   ,@JobID int
           ,@Particular nvarchar(250)
           ,@Amount int
           ,@Detail nvarchar(500)
)
AS
UPDATE [dbo].[JobPayorders]
   SET [JobID] = @JobID
      ,[Particular] = @Particular
      ,[Amount] = @Amount
      ,[Detail] = @Detail
 WHERE PayorderID = @PayorderID