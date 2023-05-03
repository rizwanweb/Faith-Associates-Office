CREATE PROCEDURE usp_BillDetailsInsertNewBillDetail

(
	 @BillDetailsID	int
	,@BillID int
	,@Particulars nvarchar(250)
	,@ReceiptNo nvarchar(250)
	,@ByYou int
	,@ByUs int
)
AS
INSERT INTO [dbo].[BillDetails]
           ([BillID]
           ,[Particulars]
           ,[ReceiptNo]
           ,[ByYou]
           ,[ByUs])
     VALUES
           (
		   @BillID
           ,@Particulars
           ,@ReceiptNo
           ,@ByYou
           ,@ByUs
)



