CREATE PROCEDURE [dbo].[usp_ItemsGetItemByHSCode]
(
	@HSCode NVARCHAR(15)
)


AS
SELECT [ItemID]
      ,[ItemName] AS 'Description'
      ,[HSCode] AS 'H.S.Code'
  FROM [dbo].[Items]
  WHERE [HSCode] LIKE '%' + @HSCode + '%'



