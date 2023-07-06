CREATE PROCEDURE [dbo].[usp_LOLOsAddNewLolo]
(
	 @LoloID INT
	,@LoloName nvarchar(100)
	,@ShortName nvarchar(50)
	,@Phone nvarchar(50)
	,@Email nvarchar(50)
)

AS
BEGIN
	INSERT INTO [dbo].[LOLOs]
			   ([LoloName]
			   ,[ShortName]
			   ,[Phone]
			   ,[Email])
		 VALUES
			   (
				 @LoloName
				,@ShortName
				,@Phone
				,@Email
			   )
END


