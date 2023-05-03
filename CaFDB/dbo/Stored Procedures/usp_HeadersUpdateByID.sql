CREATE PROCEDURE usp_HeadersUpdateByID
(
	@HeadID	INT
	,@BillHead	nvarchar(250)
)
AS

UPDATE [dbo].[BillHeaders]
   SET [BillHead] = @BillHead
 WHERE HeadID = @HeadID



