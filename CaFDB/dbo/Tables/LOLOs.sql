CREATE TABLE [dbo].[LOLOs] (
    [LoloID]    INT            IDENTITY (1, 1) NOT NULL,
    [LoloName]  NVARCHAR (100) NULL,
    [ShortName] NVARCHAR (50)  NULL,
    [Phone]     NVARCHAR (50)  NULL,
    [Email]     NVARCHAR (50)  NULL,
    CONSTRAINT [PK_LOLOs] PRIMARY KEY CLUSTERED ([LoloID] ASC)
);

