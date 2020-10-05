IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Tickets] (
    [Id] bigint NOT NULL IDENTITY,
    [Description] nvarchar(max) NOT NULL,
    [AuthorName] nvarchar(max) NULL,
    [Date] nvarchar(max) NULL,
    CONSTRAINT [PK_Tickets] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201005023408_InitialCreate', N'3.1.8');

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Tickets]') AND [c].[name] = N'Date');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Tickets] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Tickets] ALTER COLUMN [Date] nvarchar(max) NOT NULL;

GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Tickets]') AND [c].[name] = N'AuthorName');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Tickets] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Tickets] ALTER COLUMN [AuthorName] nvarchar(max) NOT NULL;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AuthorName', N'Date', N'Description') AND [object_id] = OBJECT_ID(N'[Tickets]'))
    SET IDENTITY_INSERT [Tickets] ON;
INSERT INTO [Tickets] ([Id], [AuthorName], [Date], [Description])
VALUES (CAST(1 AS bigint), N'Washington', N'26/11/2019', N'Lâmpada queimada'),
(CAST(2 AS bigint), N'Pedro', N'12/12/2019', N'Pintar parede'),
(CAST(3 AS bigint), N'João', N'07/01/2020', N'Monitor com defeito'),
(CAST(4 AS bigint), N'João', N'07/01/2020', N'Monitor com defeito');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AuthorName', N'Date', N'Description') AND [object_id] = OBJECT_ID(N'[Tickets]'))
    SET IDENTITY_INSERT [Tickets] OFF;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201005023819_Seeds', N'3.1.8');

GO