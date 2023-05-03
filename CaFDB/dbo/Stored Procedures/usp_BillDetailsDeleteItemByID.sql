CREATE PROCEDURE [dbo].[usp_BillDetailsDeleteItemByID]
(
	@BillDetailsID	INT
)
AS
DELETE FROM [dbo].[BillDetails]
      WHERE BillDetailsID = @BillDetailsID