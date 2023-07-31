CREATE PROCEDURE [dbo].[usp_ReportDepositRefundDetailByJob]
(
	 @JobStart	int
	,@SYEAR		int
	,@JobEnd	int
	,@EYEAR		int
)
AS
SELECT 
		CONCAT(j.[JobNo], '/', YEAR(j.JobDate)) AS 'Job #'
	   ,LEFT(c.ClientName, charindex(' ', c.ClientName) - 1) as 'Client'
	   --,c.ClientName
	   ,CASE
			WHEN [j].[Containers] > 0
			THEN Concat([j].[Containers], ' X ', [j].[Size])     
		ELSE
			[j].[Packages]
		END AS 'Packages'
	   --,CONCAT(j.Containers, 'X') j.Quantity
	   ,sh.ShortName
	   ,jp.Amount as 'Deposit'
	   ,jp1.Amount as 'Rent'
	   ,'' AS 'Balance'
	   ,'' AS 'Received Date'
	   ,t.ShortName as 'Terminal'
	   ,'' AS 'Refund'
	   ,'' AS 'Received Date'
      
FROM [FaithDB].[dbo].[Jobs] j
INNER JOIN Clients c on c.ClientID = j.Client
INNER JOIN ShippingLines sh ON sh.ShippingLineID = j.ShippingLine
INNER JOIN Terminals t ON t.TerminalID = j.Terminal
LEFT JOIN JobPayorders jp ON jp.JobID = j.JobID AND jp.Particular = 'CONTAINER DEPOSIT' 
LEFT JOIN JobPayorders jp1 ON jp1.JobID = j.JobID AND jp1.Particular = 'CONTAINER RENT'

WHERE j.JobNo BETWEEN @JobStart AND @JobEnd
AND YEAR(j.JobDate) BETWEEN @SYEAR AND @EYEAR

ORDER BY j.JobNo