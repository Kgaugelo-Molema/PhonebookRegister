CREATE TABLE [dbo].[Entry] (
    [Id]          UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Name]        VARCHAR (50)     NULL,
    [PhoneNumber] VARCHAR (50)     NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

