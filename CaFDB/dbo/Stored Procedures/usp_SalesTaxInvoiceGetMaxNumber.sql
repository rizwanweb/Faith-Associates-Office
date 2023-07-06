CREATE PROCEDURE [dbo].[usp_SalesTaxInvoiceGetMaxNumber]
AS
SELECT MAX([SalesTaxNo])

  FROM [dbo].[SalesTaxInvoice]



