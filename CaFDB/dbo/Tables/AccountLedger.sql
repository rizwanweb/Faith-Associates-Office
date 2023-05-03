CREATE TABLE [dbo].[AccountLedger] (
    [TransactionID]   INT            IDENTITY (1, 1) NOT NULL,
    [TransactionDate] DATE           NOT NULL,
    [ClientID]        INT            NOT NULL,
    [Particular]      NVARCHAR (150) NULL,
    [Debit]           INT            CONSTRAINT [DF__AccountLe__Debit__038683F8] DEFAULT ((0)) NOT NULL,
    [Credit]          INT            CONSTRAINT [DF__AccountLe__Credi__047AA831] DEFAULT ((0)) NOT NULL,
    [Reff]            INT            NULL,
    [drcr]            VARCHAR (50)   NULL,
    CONSTRAINT [PK__AccountL__55433A4B771EB0BD] PRIMARY KEY CLUSTERED ([TransactionID] ASC),
    CONSTRAINT [FK_Account_Clients] FOREIGN KEY ([ClientID]) REFERENCES [dbo].[Clients] ([ClientID])
);






