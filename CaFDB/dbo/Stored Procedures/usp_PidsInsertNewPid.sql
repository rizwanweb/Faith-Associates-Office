CREATE PROCEDURE [dbo].[usp_PidsInsertNewPid]

(
		 @PidID	   int
		,@PidNo    int
        ,@PidDate    date
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
        ,@DeliveryCharges    int
        ,@Wharfage    int
        ,@ContainerDeposit    int
        ,@LoloCharges    int
        ,@PSQCA1    int
        ,@PSQCA2    int
        ,@Terminal    int
        ,@ShippingLine    int
        ,@Lolo    int

		,@GD	nvarchar(100)
		,@GDDate	date
		,@Cash	nvarchar(100)
		,@CashDate	date
		,@Rent	Int
)
AS

	INSERT INTO [dbo].[Pids]
			   ([PidNo]
			   ,[PidDate]
			   ,[Client]
			   ,[LC]
			   ,[LCDate]
			   ,[Item]
			   ,[ItemDetail]
			   ,[Containers]
			   ,[Size]
			   ,[Packages]
			   ,[Vessel]
			   ,[BL]
			   ,[BLDate]
			   ,[IGM]
			   ,[IGMDate]
			   ,[IndexNo]
			   ,[Quantity]
			   ,[InvoiceValueUSD]
			   ,[ExchangeRate]
			   ,[ValueInPKR]
			   ,[Insurance]
			   ,[LandingCharges]
			   ,[ImportValuePKR]
			   ,[CustomDuty]
			   ,[CustomDutyType]
			   ,[CustomDutyRate]
			   ,[AddCustomDuty]
			   ,[AddCustomDutyType]
			   ,[AddCustomDutyRate]
			   ,[SalesTax]
			   ,[SalesTaxType]
			   ,[SalesTaxRate]
			   ,[IncomeTax]
			   ,[IncomeTaxType]
			   ,[IncomeTaxRate]
			   ,[Cess]
			   ,[CessType]
			   ,[CessRate]
			   ,[RD]
			   ,[RDType]
			   ,[RDRate]
			   ,[TotalDuty]
			   ,[DeliveryCharges]
			   ,[Wharfage]
			   ,[ContainerDeposit]
			   ,[LoloCharges]
			   ,[PSQCA1]
			   ,[PSQCA2]
			   ,[Terminal]
			   ,[ShippingLine]
			   ,[Lolo]
			   
			   ,[GD]
			   ,[GDDate]
			   ,[Cash]
			   ,[CashDate]
			   ,[Rent]
			   )
		 VALUES
			   (
			   
			    @PidNo
			   ,@PidDate
			   ,@Client
			   ,@LC
			   ,@LCDate
			   ,@Item
			   ,@ItemDetail
			   ,@Containers
			   ,@Size
			   ,@Packages
			   ,@Vessel
			   ,@BL
			   ,@BLDate
			   ,@IGM
			   ,@IGMDate
			   ,@IndexNo
			   ,@Quantity
			   ,@InvoiceValueUSD
			   ,@ExchangeRate
			   ,@ValueInPKR
			   ,@Insurance
			   ,@LandingCharges
			   ,@ImportValuePKR
			   ,@CustomDuty
			   ,@CustomDutyType
			   ,@CustomDutyRate
			   ,@AddCustomDuty
			   ,@AddCustomDutyType
			   ,@AddCustomDutyRate
			   ,@SalesTax
			   ,@SalesTaxType
			   ,@SalesTaxRate
			   ,@IncomeTax
			   ,@IncomeTaxType
			   ,@IncomeTaxRate
			   ,@Cess
			   ,@CessType
			   ,@CessRate
			   ,@RD
			   ,@RDType
			   ,@RDRate
			   ,@TotalDuty
			   ,@DeliveryCharges
			   ,@Wharfage
			   ,@ContainerDeposit
			   ,@LoloCharges
			   ,@PSQCA1
			   ,@PSQCA2
			   ,@Terminal
			   ,@ShippingLine
			   ,@Lolo
			   ,@GD
			   ,@GDDate
			   ,@Cash
			   ,@CashDate
			   ,@Rent
			   )