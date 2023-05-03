CREATE TABLE [dbo].[Clients] (
    [ClientID]      INT            IDENTITY (1, 1) NOT NULL,
    [ClientName]    NVARCHAR (250) NOT NULL,
    [ContactPerson] NVARCHAR (100) NULL,
    [Phone]         NVARCHAR (50)  NULL,
    [Mobile]        NVARCHAR (50)  NULL,
    [Email]         NVARCHAR (50)  NULL,
    [NTN]           NVARCHAR (50)  NULL,
    [GST]           NVARCHAR (50)  NULL,
    [Address]       TEXT           NULL,
    [City]          INT            NOT NULL,
    [ClientType]    NVARCHAR (50)  NULL,
    [Fax]           NVARCHAR (50)  NULL,
    [StandAddress]  NVARCHAR (500) NULL,
    CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED ([ClientID] ASC),
    CONSTRAINT [FK_Clients_Cities] FOREIGN KEY ([City]) REFERENCES [dbo].[Cities] ([CityID])
);



