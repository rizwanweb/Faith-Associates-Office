CREATE PROCEDURE [dbo].[usp_ItemsDeleteItem]
(
	@ItemID	INT
)
AS
	BEGIN
		DELETE FROM [dbo].[Items]
			  WHERE ItemID = @ItemID
	END


