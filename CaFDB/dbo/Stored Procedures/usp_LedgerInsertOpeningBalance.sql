CREATE PROCEDURE [dbo].[usp_LedgerInsertOpeningBalance]
(
	 @TransactionID	int
	,@TransactionDate date
	,@ClientID int
	,@Particular nvarchar(150)
	,@Debit int
	,@Credit int
	,@Reff	int
	,@drcr	varchar(50)
)

AS
INSERT INTO [dbo].[AccountLedger]
           ([TransactionDate]
           ,[ClientID]
           ,[Particular]
           
           ,[Debit]
		   ,[Credit]
		   ,[Reff]
		   ,[drcr]
           )
     VALUES
           (
		    @TransactionDate
           ,@ClientID
           ,@Particular
		   
           ,@Debit
		   ,@Credit
           ,@Reff
		   ,@drcr
		   )