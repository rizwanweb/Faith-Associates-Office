CREATE PROCEDURE [dbo].[usp_BillsInsertNewBill]

(
	 @BillID	int
	,@BillNo int
	,@BillDate date
	,@JobID int
	,@SubTotal int
	,@ServiceCharges int
	,@SalesTaxRate decimal(18,2)
	,@SalesTax int
	,@Total int
	,@Note nvarchar(MAX)
	,@Refund	int
	,@Balance	int
)
AS
	BEGIN
		INSERT INTO [dbo].[Bills]
				   ([BillNo]
				   ,[BillDate]
				   ,[JobID]
				   ,[SubTotal]
				   ,[ServiceCharges]
				   ,[SalesTaxRate]
				   ,[SalesTax]
				   ,[Total]
				   ,[Note]
				   ,[Refund]
				   ,[Balance])
			 VALUES
				   (
				   @BillNo
				   ,@BillDate
				   ,@JobID
				   ,@SubTotal
				   ,@ServiceCharges
				   ,@SalesTaxRate
				   ,@SalesTax
				   ,@Total
				   ,@Note
				   ,@Refund
				   ,@Balance
				   )
	END


