CREATE PROCEDURE [dbo].[usp_PidBillDetailsDeleteByBillID]
(
	@BillID	INT
)
AS
DELETE FROM [dbo].[PidBillDetails]
      WHERE BillID = @BillID



