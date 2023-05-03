CREATE PROCEDURE [dbo].[usp_JobsGetJobsByLC]
(
	@LC	nvarchar(50)
)
AS

SELECT [JobID] AS "ID"
      ,[JobNo] AS "JOB NO"
      ,[JobDate] AS "JOB DATE"
      ,[LC] AS "LC"
	  ,[Clients].[ClientName] AS "Party Name"
  FROM [dbo].[Jobs]
  INNER JOIN Clients ON Jobs.Client = Clients.ClientID
  WHERE [LC] = @LC



