CREATE PROCEDURE [dbo].[usp_LedgerInsertNewEntry]
	 @TransactionID	int
	,@TransactionDate date
	,@ClientID	int
	,@Particular	nvarchar(150)
	,@Debit	int
	,@Credit	int
	,@Reff	int
	,@drcr varchar(10)
AS
	INSERT INTO AccountLedger (TransactionDate, ClientID, Particular,Debit,Credit, Reff, drcr)
	VALUES (
			 @TransactionDate
			,@ClientID
			,@Particular
			,@Debit
			,@Credit
			,@Reff
			,@drcr
			)

