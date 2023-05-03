CREATE PROCEDURE usp_PayorderHeaderGetHeaderByJobID
(
	@JobID	INT
)
AS
SELECT [PayorderID]
      ,[JobID]
      ,[Particular]
      ,[Amount]
      ,[Detail]
  FROM [dbo].[JobPayorders]
  WHERE JobID = @JobID