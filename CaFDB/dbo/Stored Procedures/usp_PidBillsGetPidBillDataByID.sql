CREATE PROCEDURE [dbo].[usp_PidBillsGetPidBillDataByID]
(
	@BillID	int
)
AS
SELECT
       [BillDate]
      ,[SubTotal]
      ,[ServiceCharges]
      ,[Total]
  FROM [dbo].[PidBills]
  WHERE BillID = @BillID



