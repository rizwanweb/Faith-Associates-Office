CREATE PROCEDURE [dbo].[usp_PidBillsDeleteByBillID]
(
	@BillID	INT
)
AS
DELETE FROM [dbo].[PidBills]
      WHERE BillID = @BillID



