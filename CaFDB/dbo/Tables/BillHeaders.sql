CREATE TABLE [dbo].[BillHeaders] (
    [HeadID]   INT            IDENTITY (1, 1) NOT NULL,
    [BillHead] NVARCHAR (250) NULL,
    CONSTRAINT [PK_BillHeaders] PRIMARY KEY CLUSTERED ([HeadID] ASC)
);

