CREATE PROCEDURE [dbo].[usp_PidBillsInsertNewPidBill]

(
	 @BillID	int
	,@BillNo int
	,@BillDate date
	,@PidID int
	,@SubTotal int
	,@ServiceCharges int
	,@Total int
)
AS
	BEGIN
		INSERT INTO [dbo].[PidBills]
				   ([BillNo]
				   ,[BillDate]
				   ,[PidID]
				   ,[SubTotal]
				   ,[ServiceCharges]
				   ,[Total])
			 VALUES
				   (
				   @BillNo
				   ,@BillDate
				   ,@PidID
				   ,@SubTotal
				   ,@ServiceCharges

				   ,@Total
				   )
	END


