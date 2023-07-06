CREATE PROCEDURE [dbo].[usp_PayorderHeadersGetAllHeaders]
AS
SELECT [HeaderID]
      ,[Description]
      ,[PayorderDetail]
  FROM [dbo].[PayorderHeaders]