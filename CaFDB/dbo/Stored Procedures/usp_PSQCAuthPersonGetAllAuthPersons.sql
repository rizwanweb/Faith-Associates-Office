CREATE PROCEDURE usp_PSQCAuthPersonGetAllAuthPersons

AS
SELECT [PersonID]
      ,[Name]
      ,[NIC]
      ,[FatherName]
  FROM [dbo].[PSQCAuthPerson]