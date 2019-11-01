CREATE TABLE [dbo].[Characters] (
    [CharacterId] UNIQUEIDENTIFIER NOT NULL,
    [CompanyId]   UNIQUEIDENTIFIER NOT NULL,
    [Name]        NVARCHAR (50)    NULL,
    [Description] NVARCHAR (MAX)   NULL,
    CONSTRAINT [PK_Characters] PRIMARY KEY CLUSTERED ([CharacterId] ASC),
	CONSTRAINT [FK_Characters_Company] FOREIGN KEY ([CompanyId]) REFERENCES [Companies]([CompanyId])
);

