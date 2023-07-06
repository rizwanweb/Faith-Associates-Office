CREATE PROCEDURE [dbo].[usp_ItemsAddNewItem]
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
	BeGIN
		INSERT INTO [dbo].[Items]
				   ([ItemName]
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
				   ,[RDType])
			 VALUES
				   (
						@ItemName
					   ,@HSCode
					   ,@CustomDuty
					   ,@CustomDutyType
					   ,@AddCustomDuty
					   ,@AddCustomDutyType
					   ,@SalesTax
					   ,@IncomeTax
					   ,@Cess
					   ,@CessType
					   ,@RD
					   ,@RDType
				   )
	END
