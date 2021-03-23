CREATE TABLE [dbo].[Loots] (
    [LootId]      UNIQUEIDENTIFIER NOT NULL,
    [Name]        NVARCHAR (MAX)   NULL,
    [Description] NVARCHAR (MAX)   NULL,
    [Value]       DECIMAL (18, 2)  NOT NULL,
    CONSTRAINT [PK_Loots] PRIMARY KEY CLUSTERED ([LootId] ASC)
);

