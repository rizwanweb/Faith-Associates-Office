CREATE PROCEDURE [dbo].[usp_PidBillsUpdatePidBill]
(
	 @BillID	int
	,@BillNo int
	,@BillDate date
	,@PidID int
	,@Total int
	,@Refund int
	,@Balance int
	,@Note nvarchar(MAX)
)
AS
UPDATE [dbo].[PidBills]
   SET [BillNo] = @BillNo
      ,[BillDate] = @BillDate
      ,[PidID] = @PidID
      ,[Total] = @Total
	  ,[Refund] = @Refund
	  ,[Balance] = @Balance
	  ,[Note] = @Note
 WHERE BillID = @BillID



