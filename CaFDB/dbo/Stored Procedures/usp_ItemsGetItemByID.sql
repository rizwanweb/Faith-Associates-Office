CREATE PROCEDURE usp_ItemsGetItemByID
(
	@ItemID	INT
)
AS
	BEGIN
		SELECT [ItemName]
			  ,[HSCode]
			  ,[CustomDuty]
			  ,[CustomDutyType]
			  ,[AddCustomDuty]
			  ,[AddCustomDutyType]
			  ,[SalesTax]
			  ,[IncomeTax]
			  ,[Cess]
			  ,[CessType]
			  ,[RD]
			  ,[RDType]
		  FROM [dbo].[Items]
		  WHERE [ItemID] = @ItemID
	END



