CREATE PROCEDURE [dbo].[usp_PidBillDetailsGetPidBillDetailsByBillID]
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
  FROM [dbo].[PidBillDetails]
  WHERE BillID = @BillID


