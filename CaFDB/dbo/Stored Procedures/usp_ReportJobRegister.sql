CREATE PROCEDURE [dbo].[usp_ReportJobRegister]
(
	@StartDate	Date
   ,@EndDate	Date
)
AS
SELECT j.[JobNo]
	  ,CONVERT(varchar, j.JobDate, 103) AS JobDate
      ,c.[ClientName]
      ,j.[LC]
		,CASE
			WHEN j.LC = '' OR j.LC IS NULL
			THEN ''
			ELSE CONVERT(varchar, j.LCDate, 103)
		END AS 'LCDate'
	  ,Concat(j.[Containers],'X',j.[Size],' Cont')AS Containers
      ,j.[Packages]
      ,j.[IGM]
	  ,CONVERT(varchar, j.IGMDate, 103) AS IGMDate
      ,j.[IndexNo]
	  ,Convert(varchar, @StartDate, 103) AS 'StartDate'
	  ,Convert(varchar, @EndDate, 103) AS 'EndDate'

  FROM [dbo].[Jobs] j
  INNER JOIN Clients c ON j.Client = c.ClientID
  WHERE j.JobDate BETWEEN @StartDate AND @EndDate
  ORDER BY JobNo