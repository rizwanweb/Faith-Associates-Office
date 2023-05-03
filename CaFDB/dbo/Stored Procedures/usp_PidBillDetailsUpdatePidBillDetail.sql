CREATE PROCEDURE [dbo].[usp_PidBillDetailsUpdatePidBillDetail]
(
	 @BillDetailsID	int
	,@BillID int
	,@Particulars nvarchar(250)
	,@ReceiptNo nvarchar(250)
	,@ByYou int
	,@ByUs int
)
AS
UPDATE [dbo].[PidBillDetails]
   SET [Particulars] = @Particulars
      ,[ReceiptNo] = @ReceiptNo
      ,[ByYou] = @ByYou
      ,[ByUs] = @ByUs
 WHERE BillDetailsID = @BillDetailsID



