CREATE PROCEDURE [dbo].[usp_ItemsGetItemByName]
(
	@ItemName NVARCHAR(150)
)
AS
	BEGIN
		SELECT [ItemID]
			  ,[ItemName] AS 'Description'
			  ,[HSCode] AS 'H.S.Code'
		  FROM [dbo].[Items]
		  WHERE [ItemName] LIKE '%' + @ItemName + '%'
	END


