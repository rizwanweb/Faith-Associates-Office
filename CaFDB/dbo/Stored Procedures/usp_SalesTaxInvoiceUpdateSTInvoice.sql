CREATE PROCEDURE usp_SalesTaxInvoiceUpdateSTInvoice
(
	 @STID	int
    ,@SalesTaxNo int
    ,@STDate date
    ,@BillID int
    ,@Rate decimal(18,2)
    ,@SalesTax int	
)
AS
UPDATE [dbo].[SalesTaxInvoice]
   SET [SalesTaxNo] = @SalesTaxNo
      ,[STDate] = @STDate
      ,[Rate] = @Rate
      ,[SalesTax] = @SalesTax
 WHERE STID = @STID


