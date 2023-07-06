CREATE PROCEDURE [dbo].[usp_ReportBalanceSheet]
(
	 @StartDate	Date
	,@EndDate	Date
	,@ClientID	int
)
AS
SELECT  TransactionDate=NULL
	   ,Particular='Previous Balance'
	   ,ClientID=NULL 
	   ,Debit=Null
	   ,Credit=Null
	   ,drcr = Null
	   ,SUM(Debit) - SUM(Credit) AS 'Balance'
	   ,Format(@StartDate, 'dd-MM-yyyy') AS 'Start Date'
	   ,Format(@EndDate, 'dd-MM-yyyy') AS 'End Date'
FROM AccountLedger
WHERE TransactionDate < @StartDate AND ClientID = @ClientID
UNION ALL
SELECT  Convert(datetime, TransactionDate, 103)
	   ,Particular
	   ,ClientID
	   ,Debit
	   ,Credit
	   ,drcr AS 'Dr/Cr'
	   ,(Debit - Credit) AS Balance
	   ,Format(@StartDate, 'dd-MM-yyyy') AS 'Start Date'
	   ,Format(@EndDate, 'dd-MM-yyyy') AS 'End Date'
FROM AccountLedger
WHERE TransactionDate BETWEEN @StartDate AND @EndDate 
AND ClientID=@ClientID
ORDER BY TransactionDate ASC