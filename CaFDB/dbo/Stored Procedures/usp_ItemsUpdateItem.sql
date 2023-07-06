CREATE PROCEDURE [dbo].[usp_ItemsUpdateItem]
(
	 @ItemID INT
	,@ItemName nvarchar(150)
	,@HSCode nvarchar(15)
	,@CustomDuty decimal(18,2)
	,@CustomDutyType char(5)
	,@AddCustomDuty decimal(18,2)
	,@AddCustomDutyType char(10)
	,@SalesTax decimal(18,2)
	,@IncomeTax decimal(18,2)
	,@Cess decimal(18,2)
	,@CessType char(10)
	,@RD decimal(18,2)
	,@RDType char(10)
)
AS
	BEGIN
		UPDATE [dbo].[Items]
		   SET [ItemName] = @ItemName
			  ,[HSCode] = @HSCode
			  ,[CustomDuty] = @CustomDuty
			  ,[CustomDutyType] = @CustomDutyType
			  ,[AddCustomDuty] = @AddCustomDuty
			  ,[AddCustomDutyType] = @AddCustomDutyType
			  ,[SalesTax] = @SalesTax
			  ,[IncomeTax] = @IncomeTax
			  ,[Cess] = @Cess
			  ,[CessType] = @CessType
			  ,[RD] = @RD
			  ,[RDType] = @RDType
		 WHERE [ItemID] = @ItemID
	END



