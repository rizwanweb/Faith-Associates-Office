CREATE TABLE [dbo].[JobPayorders] (
    [PayorderID] INT            IDENTITY (1, 1) NOT NULL,
    [JobID]      INT            NULL,
    [Particular] NVARCHAR (250) NULL,
    [Amount]     INT            NULL,
    [Detail]     NVARCHAR (500) NULL,
    CONSTRAINT [PK_JobPayorders] PRIMARY KEY CLUSTERED ([PayorderID] ASC),
    CONSTRAINT [FK_JobPayorders_Jobs] FOREIGN KEY ([JobID]) REFERENCES [dbo].[Jobs] ([JobID])
);

