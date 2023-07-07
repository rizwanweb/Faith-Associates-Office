CREATE PROCEDURE [dbo].[usp_PidBillsUpdatePidBill]
(
	 @BillID	int
	,@BillNo int
	,@BillDate date
	,@PidID int
	,@Total int
	,@Note nvarchar(MAX)
)
AS
UPDATE [dbo].[PidBills]
   SET [BillNo] = @BillNo
      ,[BillDate] = @BillDate
      ,[PidID] = @PidID
      ,[Total] = @Total
	  ,[Note] = @Note
 WHERE BillID = @BillID



