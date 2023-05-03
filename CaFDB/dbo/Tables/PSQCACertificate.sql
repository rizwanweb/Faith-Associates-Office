CREATE TABLE [dbo].[PSQCACertificate] (
    [PSQCID]      INT            IDENTITY (1, 1) NOT NULL,
    [JobID]       INT            NULL,
    [InvoiceID]   NVARCHAR (50)  NULL,
    [InvoiceDate] DATE           NULL,
    [Origin]      NVARCHAR (50)  NULL,
    [Brand]       NVARCHAR (50)  NULL,
    [Address]     NVARCHAR (500) NULL,
    CONSTRAINT [PK_PSQCACertificate] PRIMARY KEY CLUSTERED ([PSQCID] ASC)
);

