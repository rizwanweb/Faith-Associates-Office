CREATE PROCEDURE [dbo].[usp_PidsGetClientsPids]
(
	@ClientID	INT
)
AS
SELECT [PidID]
      ,[PidNo] AS 'Pid #'
      ,[PidDate] AS 'Date'

      ,[LC] AS 'LC #'
      ,[LCDate] AS 'LC Date'
	  ,Concat([Containers], 'X',[Size], ' ',[Packages]) AS 'Packages'
  FROM [dbo].[Pids]
  WHERE Client = @ClientID