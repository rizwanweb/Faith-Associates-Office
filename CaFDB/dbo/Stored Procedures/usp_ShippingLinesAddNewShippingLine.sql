CREATE PROCEDURE [dbo].[usp_ShippingLinesAddNewShippingLine]
(
	 @ShippingLineID INT
	,@ShippingLineName nvarchar(100)
	,@ShortName nvarchar(50)
	,@Phone nvarchar(50)
	,@Email nvarchar(50)
)

AS
BEGIN
	INSERT INTO [dbo].[ShippingLines]
			   ([ShippingLineName]
			   ,[ShortName]
			   ,[Phone]
			   ,[Email])
		 VALUES
			   (
				 @ShippingLineName
				,@ShortName
				,@Phone
				,@Email
			   )
END