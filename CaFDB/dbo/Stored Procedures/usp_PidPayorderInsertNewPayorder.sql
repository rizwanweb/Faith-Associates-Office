CREATE PROCEDURE [dbo].[usp_PidPayorderInsertNewPayorder]
(
			@PayorderID INT
		   ,@PidID int
           ,@Particular nvarchar(250)
           ,@Amount int
           ,@Detail nvarchar(500)
)
AS
INSERT INTO [dbo].[PidPayorders]
           ([PidID]
           ,[Particular]
           ,[Amount]
           ,[Detail])
     VALUES
           (@PidID
           ,@Particular
           ,@Amount
           ,@Detail)