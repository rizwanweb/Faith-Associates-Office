CREATE PROCEDURE [dbo].[usp_ShippingLinesGetShippingLineDetailByID]
(
	@ShippingLineID INT	
)
AS

	BEGIN
		SELECT [ShippingLineID]
			  ,[ShippingLineName]
			  ,[ShortName]
			  ,[Phone]
			  ,[Email]

		  FROM [dbo].[ShippingLines]
		  WHERE [ShippingLineID] = @ShippingLineID
	END


