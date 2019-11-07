CREATE TABLE [dbo].[Characters] (
    [CharacterId] UNIQUEIDENTIFIER NOT NULL,
    [CompanyId]   UNIQUEIDENTIFIER NOT NULL,
    [Name]        NVARCHAR (MAX)   NULL,
    [Description] NVARCHAR (MAX)   NULL,
    [Player]      NVARCHAR (MAX)   NULL,
    CONSTRAINT [PK_Characters] PRIMARY KEY CLUSTERED ([CharacterId] ASC),
    CONSTRAINT [FK_Characters_Companies_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Companies] ([CompanyId])
);


GO
CREATE NONCLUSTERED INDEX [IX_Characters_CompanyId]
    ON [dbo].[Characters]([CompanyId] ASC);

