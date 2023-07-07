CREATE PROCEDURE [dbo].[usp_PidBillsInsertNewPidBill]

(
	 @BillID	int
	,@BillNo int
	,@BillDate date
	,@PidID int
	,@Total int
	,@Note nvarchar(MAX)
)
AS
	BEGIN
		INSERT INTO [dbo].[PidBills]
				   ([BillNo]
				   ,[BillDate]
				   ,[PidID]
				   ,[Total]
				   ,[Note])
			 VALUES
				   (
				   @BillNo
				   ,@BillDate
				   ,@PidID
				   ,@Total
				   ,@Note
				   )
	END


