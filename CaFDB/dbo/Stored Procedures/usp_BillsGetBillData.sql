CREATE PROCEDURE [dbo].[usp_BillsGetBillData]
(
	@BillID	int
)
AS
SELECT [BillID]
      ,[BillNo]
      ,[BillDate]
      ,[JobID]
      ,[SubTotal]
      ,[ServiceCharges]
      ,[SalesTaxRate]
      ,[SalesTax]
      ,[Total]
  FROM [dbo].[Bills]

