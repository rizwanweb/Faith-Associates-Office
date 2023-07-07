CREATE PROCEDURE [dbo].[usp_PidBillsGetPidBillDataByID]
(
	@BillID	int
)
AS
SELECT
       [BillDate]
      ,[Total]
	  ,[Note]
  FROM [dbo].[PidBills]
  WHERE BillID = @BillID



