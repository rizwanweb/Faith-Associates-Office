CREATE PROCEDURE [dbo].[usp_PidBillsInsertNewPidBill]

(
	 @BillID	int
	,@BillNo int
	,@BillDate date
	,@PidID int
	,@Total int
)
AS
	BEGIN
		INSERT INTO [dbo].[PidBills]
				   ([BillNo]
				   ,[BillDate]
				   ,[PidID]

				   ,[Total])
			 VALUES
				   (
				   @BillNo
				   ,@BillDate
				   ,@PidID
				   ,@Total
				   )
	END


