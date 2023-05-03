CREATE TABLE [dbo].[PidBillDetails] (
    [BillDetailsID] INT            IDENTITY (1, 1) NOT NULL,
    [BillID]        INT            NULL,
    [Particulars]   NVARCHAR (250) NULL,
    [ReceiptNo]     NVARCHAR (250) NULL,
    [ByYou]         INT            NULL,
    [ByUs]          INT            NULL,
    CONSTRAINT [PK_PidBillDetails] PRIMARY KEY CLUSTERED ([BillDetailsID] ASC),
    CONSTRAINT [FK_PidBillDetails_PidBills] FOREIGN KEY ([BillID]) REFERENCES [dbo].[PidBills] ([BillID])
);

