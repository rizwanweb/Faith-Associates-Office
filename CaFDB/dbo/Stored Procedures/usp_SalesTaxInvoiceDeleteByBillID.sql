CREATE PROCEDURE [dbo].[usp_SalesTaxInvoiceDeleteByBillID]
(
	@BillID	INT
)
AS
DELETE FROM [dbo].[SalesTaxInvoice]
      WHERE BillID = @BillID



