CREATE PROCEDURE [dbo].[usp_BillDetailsUpdateBillDetail]

(
	 @BillDetailsID	int
	,@BillID int
	,@Particulars nvarchar(250)
	,@ReceiptNo nvarchar(250)
	,@ByYou int
	,@ByUs int
)
AS
IF EXISTS (SELECT * FROM BillDetails WHERE BillDetailsID = @BillDetailsID)
BEGIN
   UPDATE [dbo].[BillDetails]
   SET [Particulars] = @Particulars
      ,[ReceiptNo] = @ReceiptNo
      ,[ByYou] = @ByYou
      ,[ByUs] = @ByUs
   WHERE BillDetailsID = @BillDetailsID
END
ELSE
BEGIN
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
END



