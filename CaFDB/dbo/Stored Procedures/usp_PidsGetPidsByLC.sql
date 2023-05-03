CREATE PROCEDURE [dbo].[usp_PidsGetPidsByLC]
(
	@LC	nvarchar(50)
)
AS

SELECT [PidID] AS "ID"
      ,[PidNo] AS "Pid NO"
      ,[PidDate] AS "Pid DATE"
      ,[LC] AS "LC"
	  ,[Clients].[ClientName] AS "Party Name"
  FROM [dbo].[Pids]
  INNER JOIN Clients ON Pids.Client = Clients.ClientID
  WHERE [LC] = @LC



