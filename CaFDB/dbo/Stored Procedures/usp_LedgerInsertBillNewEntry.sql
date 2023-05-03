CREATE PROCEDURE [dbo].[usp_LedgerInsertBillNewEntry]
	 @TransactionID	int
	,@TransactionDate date
	,@ClientID	int
	,@Particular	nvarchar(150)
	,@Debit	int
	,@Credit	int
	,@Reff	int
AS
	INSERT INTO AccountLedger (TransactionDate, ClientID, Particular,Debit,Credit, Reff)
	VALUES (
			 @TransactionDate
			,@ClientID
			,@Particular
			,@Debit
			,@Credit
			,@Reff
			)