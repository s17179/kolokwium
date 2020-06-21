IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Artist] (
    [IdArtist] int NOT NULL IDENTITY,
    [Nickname] nvarchar(30) NOT NULL,
    CONSTRAINT [PK_Artist] PRIMARY KEY ([IdArtist])
);

GO

CREATE TABLE [Event] (
    [IdEvent] int NOT NULL IDENTITY,
    [Name] nvarchar(100) NOT NULL,
    [StartDate] datetime2 NOT NULL,
    [EndDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Event] PRIMARY KEY ([IdEvent])
);

GO

CREATE TABLE [Organiser] (
    [IdOrganiser] int NOT NULL IDENTITY,
    [Name] nvarchar(30) NOT NULL,
    CONSTRAINT [PK_Organiser] PRIMARY KEY ([IdOrganiser])
);

GO

CREATE TABLE [ArtistEvent] (
    [IdEvent] int NOT NULL,
    [IdArtist] int NOT NULL,
    [PerformanceDate] datetime2 NOT NULL,
    CONSTRAINT [PK_ArtistEvent] PRIMARY KEY ([IdArtist], [IdEvent]),
    CONSTRAINT [FK_ArtistEvent_Artist_IdArtist] FOREIGN KEY ([IdArtist]) REFERENCES [Artist] ([IdArtist]) ON DELETE CASCADE,
    CONSTRAINT [FK_ArtistEvent_Event_IdEvent] FOREIGN KEY ([IdEvent]) REFERENCES [Event] ([IdEvent]) ON DELETE CASCADE
);

GO

CREATE TABLE [EventOrganiser] (
    [IdEvent] int NOT NULL,
    [IdOrganiser] int NOT NULL,
    CONSTRAINT [PK_EventOrganiser] PRIMARY KEY ([IdEvent], [IdOrganiser]),
    CONSTRAINT [FK_EventOrganiser_Event_IdEvent] FOREIGN KEY ([IdEvent]) REFERENCES [Event] ([IdEvent]) ON DELETE CASCADE,
    CONSTRAINT [FK_EventOrganiser_Organiser_IdOrganiser] FOREIGN KEY ([IdOrganiser]) REFERENCES [Organiser] ([IdOrganiser]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_ArtistEvent_IdEvent] ON [ArtistEvent] ([IdEvent]);

GO

CREATE INDEX [IX_EventOrganiser_IdOrganiser] ON [EventOrganiser] ([IdOrganiser]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200621170006_Init', N'3.1.5');

GO

