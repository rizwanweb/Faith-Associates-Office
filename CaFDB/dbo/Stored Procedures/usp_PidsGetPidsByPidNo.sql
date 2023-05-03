CREATE PROCEDURE [dbo].[usp_PidsGetPidsByPidNo]
(
	@PidNo	INT
)
AS

SELECT [PidID] AS "ID"
      ,[PidNo] AS "PID NO"
      ,[PidDate] AS "PID DATE"
      ,[LC] AS "LC"
	  ,[Clients].[ClientName] AS "Party Name"
  FROM [dbo].[Pids]
  INNER JOIN Clients ON Pids.Client = Clients.ClientID
  WHERE PidNo = @PidNo



