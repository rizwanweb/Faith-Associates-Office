CREATE PROCEDURE [dbo].[usp_PidBillsGetPidBillDataByID]
(
	@BillID	int
)
AS
SELECT
       [BillDate]
      ,[Total]
	  ,[Refund]
	  ,[Balance]
	  ,[Note]
  FROM [dbo].[PidBills]
  WHERE BillID = @BillID



