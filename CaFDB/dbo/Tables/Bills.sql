CREATE TABLE [dbo].[Bills] (
    [BillID]         INT             IDENTITY (1, 1) NOT NULL,
    [BillNo]         INT             NOT NULL,
    [BillDate]       DATE            NOT NULL,
    [JobID]          INT             NULL,
    [SubTotal]       INT             NOT NULL,
    [ServiceCharges] INT             NULL,
    [SalesTaxRate]   DECIMAL (18, 2) NULL,
    [SalesTax]       INT             NULL,
    [Total]          INT             NULL,
    [Note]           NVARCHAR (MAX)  NULL,
    CONSTRAINT [PK_Bills] PRIMARY KEY CLUSTERED ([BillID] ASC),
    CONSTRAINT [FK_Bills_Jobs] FOREIGN KEY ([JobID]) REFERENCES [dbo].[Jobs] ([JobID])
);









