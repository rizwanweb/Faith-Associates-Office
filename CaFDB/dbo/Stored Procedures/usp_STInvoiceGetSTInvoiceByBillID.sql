﻿CREATE PROCEDURE [dbo].[usp_STInvoiceGetSTInvoiceByBillID]
(
	@BillID	INT
)
AS
SELECT [STID]
  FROM [dbo].[SalesTaxInvoice]
  WHERE BillID = @BillID



