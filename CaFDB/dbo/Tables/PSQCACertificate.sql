CREATE TABLE [dbo].[PSQCACertificate] (
    [PSQCID]           INT           IDENTITY (1, 1) NOT NULL,
    [JobID]            INT           NULL,
    [Invoice]          NVARCHAR (50) NULL,
    [InvoiceDate]      DATE          NULL,
    [Origin]           NVARCHAR (50) NULL,
    [Brand]            NVARCHAR (50) NULL,
    [AuthorizedPerson] INT           NULL,
    CONSTRAINT [PK_PSQCACertificate] PRIMARY KEY CLUSTERED ([PSQCID] ASC),
    CONSTRAINT [FK_PSQCACertificate_PSQCAuthPerson] FOREIGN KEY ([AuthorizedPerson]) REFERENCES [dbo].[PSQCAuthPerson] ([PersonID])
);



