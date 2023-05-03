CREATE PROCEDURE usp_ShippingLinesUpdateShippingLine
(
	 @ShippingLineID INT
	,@ShippingLineName nvarchar(100)
	,@ShortName nvarchar(50)
	,@Phone nvarchar(50)
	,@Email nvarchar(50)
)
AS
BEGIN
UPDATE [dbo].[ShippingLines]
   SET [ShippingLineName] = @ShippingLineName
      ,[ShortName] = @ShortName
      ,[Phone] = @Phone
      ,[Email] = @Email
 WHERE ShippingLineID = @ShippingLineID
END


