CREATE TABLE [dbo].[Items] (
    [ItemID]            INT             IDENTITY (1, 1) NOT NULL,
    [ItemName]          NVARCHAR (150)  NOT NULL,
    [HSCode]            NVARCHAR (15)   NOT NULL,
    [CustomDuty]        DECIMAL (18, 2) NULL,
    [CustomDutyType]    INT             NULL,
    [AddCustomDuty]     DECIMAL (18, 2) NULL,
    [AddCustomDutyType] INT             NULL,
    [SalesTax]          DECIMAL (18, 2) NULL,
    [IncomeTax]         DECIMAL (18, 2) NULL,
    [Cess]              DECIMAL (18, 2) NULL,
    [CessType]          INT             NULL,
    [RD]                DECIMAL (18, 2) NULL,
    [RDType]            INT             NULL,
    CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED ([ItemID] ASC)
);

