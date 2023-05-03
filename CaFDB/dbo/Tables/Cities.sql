CREATE TABLE [dbo].[Cities] (
    [CityID]   INT           IDENTITY (1, 1) NOT NULL,
    [CityName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED ([CityID] ASC)
);

