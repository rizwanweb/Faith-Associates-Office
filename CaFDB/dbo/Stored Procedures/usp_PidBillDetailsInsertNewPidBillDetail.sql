CREATE PROCEDURE [dbo].[usp_PidBillDetailsInsertNewPidBillDetail]

(
	 @BillDetailsID	int
	,@BillID int
	,@Particulars nvarchar(250)
	,@ReceiptNo nvarchar(250)
	,@ByYou int
	,@ByUs int
)
AS
INSERT INTO [dbo].[PidBillDetails]
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



