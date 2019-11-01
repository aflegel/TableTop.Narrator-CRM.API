CREATE TABLE [dbo].[Encounters] (
    [EncounterId] UNIQUEIDENTIFIER NOT NULL,
    [CompanyId]   UNIQUEIDENTIFIER NOT NULL,
    [Title]       NVARCHAR (50)    NULL,
    [Description] NVARCHAR (MAX)   NULL,
    CONSTRAINT [PK_Encounters] PRIMARY KEY CLUSTERED ([EncounterId] ASC),
	CONSTRAINT [FK_Encounters_Company] FOREIGN KEY ([CompanyId]) REFERENCES [Companies]([CompanyId])
);

