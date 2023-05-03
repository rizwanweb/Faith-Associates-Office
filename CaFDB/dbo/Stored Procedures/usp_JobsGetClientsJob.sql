CREATE PROCEDURE usp_JobsGetClientsJob
(
	@ClientID	INT
)
AS
SELECT [JobID]
      ,[JobNo] AS 'Job #'
      ,[JobDate] AS 'Date'

      ,[LC] AS 'LC #'
      ,[LCDate] AS 'LC Date'
	  ,Concat([Containers], 'X',[Size], ' ',[Packages]) AS 'Packages'
  FROM [dbo].[Jobs]
  WHERE Client = @ClientID