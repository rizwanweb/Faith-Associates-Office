CREATE PROCEDURE [dbo].[usp_PidPayorderUpdatePayorder]
(
			@PayorderID INT
		   ,@PidID int
           ,@Particular nvarchar(250)
           ,@Amount int
           ,@Detail nvarchar(500)
)
AS
UPDATE [dbo].[PidPayorders]
   SET [PidID] = @PidID
      ,[Particular] = @Particular
      ,[Amount] = @Amount
      ,[Detail] = @Detail
 WHERE PayorderID = @PayorderID