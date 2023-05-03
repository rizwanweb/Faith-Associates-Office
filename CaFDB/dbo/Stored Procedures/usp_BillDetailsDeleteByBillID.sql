CREATE PROCEDURE usp_BillDetailsDeleteByBillID
(
	@BillID	INT
)
AS
DELETE FROM [dbo].[BillDetails]
      WHERE BillID = @BillID



