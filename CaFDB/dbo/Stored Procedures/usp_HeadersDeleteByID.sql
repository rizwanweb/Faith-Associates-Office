CREATE PROCEDURE [dbo].[usp_HeadersDeleteByID]
(
	@HeadID	INT
)
AS

DELETE FROM [dbo].[BillHeaders]
      WHERE HeadID = @HeadID



