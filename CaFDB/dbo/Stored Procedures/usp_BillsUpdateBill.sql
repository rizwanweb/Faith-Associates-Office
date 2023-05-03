CREATE PROCEDURE usp_BillsUpdateBill
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
)
AS
UPDATE [dbo].[Bills]
   SET [BillNo] = @BillNo
      ,[BillDate] = @BillDate
      ,[JobID] = @JobID
      ,[SubTotal] = @SubTotal
      ,[ServiceCharges] = @ServiceCharges
      ,[SalesTaxRate] = @SalesTaxRate
      ,[SalesTax] = @SalesTax
      ,[Total] = @Total
 WHERE BillID = @BillID



