CREATE TABLE [dbo].[SalesTaxInvoice] (
    [STID]       INT             IDENTITY (1, 1) NOT NULL,
    [SalesTaxNo] INT             NULL,
    [STDate]     DATE            NULL,
    [BillID]     INT             NULL,
    [Rate]       DECIMAL (18, 2) NULL,
    [SalesTax]   INT             NULL,
    CONSTRAINT [PK_SalesTaxInvoice] PRIMARY KEY CLUSTERED ([STID] ASC),
    CONSTRAINT [FK_SalesTaxInvoice_Bills] FOREIGN KEY ([BillID]) REFERENCES [dbo].[Bills] ([BillID])
);

