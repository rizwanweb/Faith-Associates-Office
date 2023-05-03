CREATE TABLE [dbo].[PayorderHeaders] (
    [HeaderID]       INT            IDENTITY (1, 1) NOT NULL,
    [Description]    NVARCHAR (250) NULL,
    [PayorderDetail] NVARCHAR (250) NULL,
    CONSTRAINT [PK_PayorderHeaders] PRIMARY KEY CLUSTERED ([HeaderID] ASC)
);

