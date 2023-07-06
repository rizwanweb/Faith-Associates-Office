CREATE PROCEDURE [dbo].[usp_LOLOsUpdateLolo]
(
	 @LoloID INT
	,@LoloName nvarchar(100)
	,@ShortName nvarchar(50)
	,@Phone nvarchar(50)
	,@Email nvarchar(50)
)
AS
BEGIN
UPDATE [dbo].[LOLOs]
   SET [LoloName] = @LoloName
      ,[ShortName] = @ShortName
      ,[Phone] = @Phone
      ,[Email] = @Email
 WHERE LoloID = @LoloID
END


