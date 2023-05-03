CREATE PROCEDURE usp_SalesTaxInvoiceGetMaxNumber
AS
SELECT MAX([SalesTaxNo])

  FROM [dbo].[SalesTaxInvoice]



