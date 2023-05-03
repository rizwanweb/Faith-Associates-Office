CREATE PROCEDURE usp_PayorderHeadersGetAllHeaders
AS
SELECT [HeaderID]
      ,[Description]
      ,[PayorderDetail]
  FROM [dbo].[PayorderHeaders]