CREATE PROCEDURE [dbo].[usp_SalesTaxInvoiceInsertNewSalesTaxInvoice]
(
@STID  int
,@SalesTaxNo  int
,@STDate	Date
,@BillID  int
,@Rate  decimal(18,2)
,@SalesTax  int
)
AS
INSERT INTO [dbo].[SalesTaxInvoice]
           (
            [SalesTaxNo]
		   ,[STDate]
           ,[BillID]
           ,[Rate]
           ,[SalesTax])
     VALUES
           (
            @SalesTaxNo
		   ,@STDate
           ,@BillID
           ,@Rate
           ,@SalesTax
		   )
