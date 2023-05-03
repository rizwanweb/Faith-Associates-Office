CREATE PROCEDURE [dbo].[usp_JobsUpdateJob]

(
		 @JobID	   int
		,@JobNo    int
        ,@JobDate    date
        ,@Client    int
        ,@LC    nvarchar(50)
        ,@LCDate    date
        ,@Item    int
        ,@ItemDetail    nvarchar(250)
        ,@Containers    int
        ,@Size    int
        ,@Packages    nvarchar(150)
        ,@Vessel    nvarchar(50)
        ,@BL    nvarchar(50)
        ,@BLDate    date
        ,@IGM    int
        ,@IGMDate    date
        ,@IndexNo    int
        ,@Quantity    int
        ,@InvoiceValueUSD    decimal(18,2)
        ,@ExchangeRate    decimal(18,2)
        ,@ValueInPKR    int
        ,@Insurance    decimal(18,2)
        ,@LandingCharges    int
        ,@ImportValuePKR    int
        ,@CustomDuty    int
		,@CustomDutyType    nvarchar(5)
		,@CustomDutyRate    decimal(18,2)
        ,@AddCustomDuty    int
		,@AddCustomDutyType    nvarchar(5)
		,@AddCustomDutyRate    decimal(18,2)
        ,@SalesTax    int
		,@SalesTaxType    nvarchar(5)
		,@SalesTaxRate    decimal(18,2)
        ,@IncomeTax    int
		,@IncomeTaxType    nvarchar(5)
		,@IncomeTaxRate    decimal(18,2)
        ,@Cess    int
		,@CessType    nvarchar(5)
		,@CessRate    decimal(18,2)
        ,@RD    int
		,@RDType    nvarchar(5)
		,@RDRate    decimal(18,2)
        ,@TotalDuty    int

        ,@Terminal    int
        ,@ShippingLine    int
        ,@Lolo    int

		,@GD	nvarchar(100)
		,@GDDate	date
		,@Cash	nvarchar(100)
		,@CashDate	date

)
AS

UPDATE [dbo].[Jobs]
   SET [JobNo] = @JobNo
      ,[JobDate] = @JobDate
      ,[Client] = @Client
      ,[LC] = @LC
      ,[LCDate] = @LCDate
      ,[Item] = @Item
      ,[ItemDetail] = @ItemDetail
      ,[Containers] = @Containers
      ,[Size] = @Size
      ,[Packages] = @Packages
      ,[Vessel] = @Vessel 
      ,[BL] = @BL
      ,[BLDate] = @BLDate
      ,[IGM] = @IGM
      ,[IGMDate] = @IGMDate
      ,[IndexNo] = @IndexNo
      ,[Quantity] = @Quantity 
      ,[InvoiceValueUSD] = @InvoiceValueUSD
      ,[ExchangeRate] = @ExchangeRate
      ,[ValueInPKR] = @ValueInPKR
      ,[Insurance] = @Insurance
      ,[LandingCharges] = @LandingCharges
      ,[ImportValuePKR] = @ImportValuePKR
      ,[CustomDuty] = @CustomDuty
      ,[CustomDutyType] = @CustomDutyType
      ,[CustomDutyRate] = @CustomDutyRate
      ,[AddCustomDuty] = @AddCustomDuty 
      ,[AddCustomDutyType] = @AddCustomDutyType
      ,[AddCustomDutyRate] = @AddCustomDutyRate
      ,[SalesTax] = @SalesTax 
      ,[SalesTaxType] = @SalesTaxType
      ,[SalesTaxRate] = @SalesTaxRate
      ,[IncomeTax] = @IncomeTax
      ,[IncomeTaxType] = @IncomeTaxType
      ,[IncomeTaxRate] = @IncomeTaxRate
      ,[Cess] = @Cess
      ,[CessType] = @CessType
      ,[CessRate] = @CessRate
      ,[RD] = @RD
      ,[RDType] = @RDType
      ,[RDRate] = @RDRate
      ,[TotalDuty] = @TotalDuty

      ,[Terminal] = @Terminal
      ,[ShippingLine] = @ShippingLine
      ,[Lolo] = @Lolo

	  ,[GD] = @GD
	  ,[GDDate] = @GDDate
	  ,[Cash] = @Cash
	  ,[CashDate] = @CashDate


 WHERE JobID = @JobID



