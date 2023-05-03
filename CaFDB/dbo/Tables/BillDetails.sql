CREATE TABLE [dbo].[BillDetails] (
    [BillDetailsID] INT            IDENTITY (1, 1) NOT NULL,
    [BillID]        INT            NULL,
    [Particulars]   NVARCHAR (250) NULL,
    [ReceiptNo]     NVARCHAR (250) NULL,
    [ByYou]         INT            NULL,
    [ByUs]          INT            NULL,
    CONSTRAINT [PK_BillDetails] PRIMARY KEY CLUSTERED ([BillDetailsID] ASC),
    CONSTRAINT [FK_BillDetails_Bills] FOREIGN KEY ([BillID]) REFERENCES [dbo].[Bills] ([BillID])
);

