CREATE PROCEDURE [dbo].[usp_LedgerGetTransactionID]
@Reff	int
AS
SELECT [TransactionID]
  FROM [dbo].[AccountLedger]
  WHERE Reff = @Reff