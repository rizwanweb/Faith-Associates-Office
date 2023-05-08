CREATE TABLE [dbo].[PidPayorders] (
    [PayorderID] INT            IDENTITY (1, 1) NOT NULL,
    [PidID]      INT            NULL,
    [Particular] NVARCHAR (250) NULL,
    [Amount]     INT            NULL,
    [Detail]     NVARCHAR (500) NULL,
    CONSTRAINT [PK_PIDPayorders] PRIMARY KEY CLUSTERED ([PayorderID] ASC),
    CONSTRAINT [FK_PIDPayorders_Pids] FOREIGN KEY ([PidID]) REFERENCES [dbo].[Pids] ([PidID])
);

