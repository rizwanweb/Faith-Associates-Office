CREATE TABLE [dbo].[Terminals] (
    [TerminalID]   INT            IDENTITY (1, 1) NOT NULL,
    [TerminalName] NVARCHAR (100) NULL,
    [ShortName]    NVARCHAR (50)  NULL,
    [Phone]        NVARCHAR (50)  NULL,
    [Email]        NVARCHAR (50)  NULL,
    CONSTRAINT [PK_Terminals] PRIMARY KEY CLUSTERED ([TerminalID] ASC)
);

