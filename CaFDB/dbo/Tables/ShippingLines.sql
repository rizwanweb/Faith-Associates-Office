CREATE TABLE [dbo].[ShippingLines] (
    [ShippingLineID]   INT            IDENTITY (1, 1) NOT NULL,
    [ShippingLineName] NVARCHAR (100) NULL,
    [ShortName]        NVARCHAR (50)  NULL,
    [Phone]            NVARCHAR (50)  NULL,
    [Email]            NVARCHAR (50)  NULL,
    CONSTRAINT [PK_ShippingLines] PRIMARY KEY CLUSTERED ([ShippingLineID] ASC)
);

