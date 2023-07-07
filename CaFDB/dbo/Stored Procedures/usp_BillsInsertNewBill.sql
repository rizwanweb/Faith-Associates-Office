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
					)
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
				   )
	END


