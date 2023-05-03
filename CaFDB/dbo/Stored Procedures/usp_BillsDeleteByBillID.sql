CREATE PROCEDURE usp_BillsDeleteByBillID
(
	@BillID	INT
)
AS
DELETE FROM [dbo].[Bills]
      WHERE BillID = @BillID



