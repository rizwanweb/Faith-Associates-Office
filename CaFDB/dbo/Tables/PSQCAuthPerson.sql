CREATE TABLE [dbo].[PSQCAuthPerson] (
    [PersonID]   INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (100) NULL,
    [NIC]        NVARCHAR (50)  NULL,
    [FatherName] NVARCHAR (50)  NULL,
    CONSTRAINT [PK_PSQCAuthPerson] PRIMARY KEY CLUSTERED ([PersonID] ASC)
);

