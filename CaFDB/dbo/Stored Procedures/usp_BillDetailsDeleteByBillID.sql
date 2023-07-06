CREATE PROCEDURE [dbo].[usp_BillDetailsDeleteByBillID]
(
	@BillID	INT
)
AS
DELETE FROM [dbo].[BillDetails]
      WHERE BillID = @BillID



