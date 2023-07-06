CREATE PROCEDURE [dbo].[usp_ItemsGetAllItems]

AS
SELECT [ItemID]
      ,[ItemName] AS 'Description'
      ,[HSCode] AS 'H.S.Code'
  FROM [dbo].[Items]

