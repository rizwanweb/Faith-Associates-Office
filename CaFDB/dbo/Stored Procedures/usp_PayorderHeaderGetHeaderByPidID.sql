CREATE PROCEDURE [dbo].[usp_PayorderHeaderGetHeaderByPidID]
(
	@PidID	INT
)
AS
SELECT [PayorderID]
      ,[PidID]
      ,[Particular]
      ,[Amount]
      ,[Detail]
  FROM [dbo].[PidPayorders]
  WHERE PidID = @PidID