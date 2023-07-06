CREATE PROCEDURE [dbo].[usp_BillDetailsGetBillDetailsByBillID]
(
	@BillID	int
)
AS
SELECT [BillDetailsID]
      ,[BillID]
      ,[Particulars]
      ,[ReceiptNo]
      ,[ByYou]
      ,[ByUs]
  FROM [dbo].[BillDetails]
  WHERE BillID = @BillID


