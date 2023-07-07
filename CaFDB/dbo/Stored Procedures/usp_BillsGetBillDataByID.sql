﻿CREATE PROCEDURE [dbo].[usp_BillsGetBillDataByID]
(
	@BillID	int
)
AS
SELECT
       [BillDate]
      ,[SubTotal]
      ,[ServiceCharges]
      ,[SalesTaxRate]
      ,Bills.[SalesTax]
      ,[Total]
	  ,[Note]
	  ,SalesTaxInvoice.SalesTaxNo
  FROM [dbo].[Bills]
  INNER JOIN SalesTaxInvoice ON bills.BillID = SalesTaxInvoice.BillID
  WHERE Bills.BillID = @BillID



