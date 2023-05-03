CREATE TABLE [dbo].[ClientTypes] (
    [TypeID]      INT           IDENTITY (1, 1) NOT NULL,
    [Description] NVARCHAR (50) NULL,
    CONSTRAINT [PK_ClientTypes] PRIMARY KEY CLUSTERED ([TypeID] ASC)
);

