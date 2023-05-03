CREATE PROCEDURE [dbo].[usp_LedgerUpdateLedgerEntryTotal]
 @Total	int
,@TransactionID	int
AS
UPDATE [dbo].[AccountLedger]
   SET [Debit] = @Total

 WHERE TransactionID = @TransactionID