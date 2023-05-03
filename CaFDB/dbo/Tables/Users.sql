CREATE TABLE [dbo].[Users] (
    [UserID]   INT            IDENTITY (1, 1) NOT NULL,
    [Username] NVARCHAR (MAX) NULL,
    [Password] NVARCHAR (50)  NULL,
    [Role]     INT            NULL,
    PRIMARY KEY CLUSTERED ([UserID] ASC)
);

