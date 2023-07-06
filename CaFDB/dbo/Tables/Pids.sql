CREATE TABLE [dbo].[Pids] (
    [PidID]             INT             IDENTITY (1, 1) NOT NULL,
    [PidNo]             INT             NOT NULL,
    [PidDate]           DATE            NOT NULL,
    [Client]            INT             NOT NULL,
    [LC]                NVARCHAR (50)   NULL,
    [LCDate]            DATE            NULL,
    [Item]              INT             NULL,
    [ItemDetail]        NVARCHAR (250)  NULL,
    [Containers]        INT             NULL,
    [Size]              INT             NULL,
    [Packages]          NVARCHAR (150)  NULL,
    [Vessel]            NVARCHAR (50)   NULL,
    [BL]                NVARCHAR (50)   NULL,
    [BLDate]            DATE            NULL,
    [IGM]               INT             NULL,
    [IGMDate]           DATE            NULL,
    [IndexNo]           INT             NULL,
    [Quantity]          INT             NULL,
    [InvoiceValueUSD]   DECIMAL (18, 2) NOT NULL,
    [ExchangeRate]      DECIMAL (18, 2) NOT NULL,
    [ValueInPKR]        INT             NULL,
    [Insurance]         INT             NULL,
    [LandingCharges]    INT             NULL,
    [ImportValuePKR]    INT             NULL,
    [CustomDuty]        INT             NULL,
    [CustomDutyType]    NVARCHAR (5)    NULL,
    [CustomDutyRate]    DECIMAL (18, 2) NULL,
    [AddCustomDuty]     INT             NULL,
    [AddCustomDutyType] NVARCHAR (5)    NULL,
    [AddCustomDutyRate] DECIMAL (18, 2) NULL,
    [SalesTax]          INT             NULL,
    [SalesTaxType]      NVARCHAR (5)    NULL,
    [SalesTaxRate]      DECIMAL (18, 2) NULL,
    [IncomeTax]         INT             NULL,
    [IncomeTaxType]     NVARCHAR (5)    NULL,
    [IncomeTaxRate]     DECIMAL (18, 2) NULL,
    [Cess]              INT             NULL,
    [CessType]          NVARCHAR (5)    NULL,
    [CessRate]          DECIMAL (18, 2) NULL,
    [RD]                INT             NULL,
    [RDType]            NVARCHAR (5)    NULL,
    [RDRate]            DECIMAL (18, 2) NULL,
    [TotalDuty]         INT             NULL,
    [Terminal]          INT             NULL,
    [ShippingLine]      INT             NULL,
    [Lolo]              INT             NULL,
    [GD]                NVARCHAR (100)  NULL,
    [GDDate]            DATE            NULL,
    [Cash]              NVARCHAR (100)  NULL,
    [CashDate]          DATE            NULL,
    CONSTRAINT [PK_Pids] PRIMARY KEY CLUSTERED ([PidID] ASC),
    CONSTRAINT [FK_Pids_Clients] FOREIGN KEY ([Client]) REFERENCES [dbo].[Clients] ([ClientID]),
    CONSTRAINT [FK_Pids_Item] FOREIGN KEY ([Item]) REFERENCES [dbo].[Items] ([ItemID]),
    CONSTRAINT [FK_Pids_Lolo] FOREIGN KEY ([Lolo]) REFERENCES [dbo].[LOLOs] ([LoloID]),
    CONSTRAINT [FK_Pids_ShippingLine] FOREIGN KEY ([ShippingLine]) REFERENCES [dbo].[ShippingLines] ([ShippingLineID]),
    CONSTRAINT [FK_Pids_Terminal] FOREIGN KEY ([Terminal]) REFERENCES [dbo].[Terminals] ([TerminalID])
);


GO
ALTER TABLE [dbo].[Pids] NOCHECK CONSTRAINT [FK_Pids_Lolo];


GO
ALTER TABLE [dbo].[Pids] NOCHECK CONSTRAINT [FK_Pids_ShippingLine];


GO
ALTER TABLE [dbo].[Pids] NOCHECK CONSTRAINT [FK_Pids_Terminal];






GO



GO



GO





GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Job to Client relation', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Pids', @level2type = N'CONSTRAINT', @level2name = N'FK_Pids_Clients';

