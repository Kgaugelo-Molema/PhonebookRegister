CREATE TABLE [dbo].[Phonebook] (
    [Id]      UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Name]    NVARCHAR (50)    NULL,
    [EntryId] UNIQUEIDENTIFIER NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

