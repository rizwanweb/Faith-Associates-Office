CREATE TABLE [dbo].[Roles] (
    [RoleID]      INT           IDENTITY (1, 1) NOT NULL,
    [Description] NVARCHAR (50) NULL,
    [Notes]       NVARCHAR (50) NULL,
    [CreatedBy]   NVARCHAR (50) NULL,
    [CreatedDate] DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([RoleID] ASC)
);

