CREATE PROCEDURE usp_ShippingLinesDeleteShippingLine
(
	@ShippingLineID	INT
)
AS
DELETE FROM [dbo].[ShippingLines]
      WHERE ShippingLineID = @ShippingLineID


