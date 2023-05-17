CREATE PROCEDURE [dbo].[usp_BillsUpdateBill]
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
UPDATE [dbo].[Bills]
   SET [BillNo] = @BillNo
      ,[BillDate] = @BillDate
      ,[JobID] = @JobID
      ,[SubTotal] = @SubTotal
      ,[ServiceCharges] = @ServiceCharges
      ,[SalesTaxRate] = @SalesTaxRate
      ,[SalesTax] = @SalesTax
      ,[Total] = @Total
	  ,[Note] = @Note
 WHERE BillID = @BillID



