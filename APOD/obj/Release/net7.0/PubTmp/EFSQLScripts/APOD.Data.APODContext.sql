IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230315153334_InitialCreate')
BEGIN
    CREATE TABLE [APOD] (
        [Id] int NOT NULL IDENTITY,
        [Title] nvarchar(max) NULL,
        [date] nvarchar(max) NULL,
        [explanation] nvarchar(max) NULL,
        [hdurl] nvarchar(max) NULL,
        CONSTRAINT [PK_APOD] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230315153334_InitialCreate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230315153334_InitialCreate', N'7.0.4');
END;
GO

COMMIT;
GO

