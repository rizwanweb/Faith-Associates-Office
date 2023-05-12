CREATE TABLE [dbo].[PidBills] (
    [BillID]   INT  IDENTITY (1, 1) NOT NULL,
    [BillNo]   INT  NOT NULL,
    [BillDate] DATE NOT NULL,
    [PidID]    INT  NULL,
    [Total]    INT  NULL,
    CONSTRAINT [PK_PidBills] PRIMARY KEY CLUSTERED ([BillID] ASC),
    CONSTRAINT [FK_PidBills_Pids] FOREIGN KEY ([PidID]) REFERENCES [dbo].[Pids] ([PidID])
);



