CREATE PROCEDURE usp_JobPayorderInsertNewPayorder
(
			@PayorderID INT
		   ,@JobID int
           ,@Particular nvarchar(250)
           ,@Amount int
           ,@Detail nvarchar(500)
)
AS
INSERT INTO [dbo].[JobPayorders]
           ([JobID]
           ,[Particular]
           ,[Amount]
           ,[Detail])
     VALUES
           (@JobID
           ,@Particular
           ,@Amount
           ,@Detail)