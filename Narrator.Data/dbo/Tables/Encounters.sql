CREATE TABLE [dbo].[Encounters] (
    [EncounterId] UNIQUEIDENTIFIER NOT NULL,
    [CompanyId]   UNIQUEIDENTIFIER NOT NULL,
    [Name]        NVARCHAR (MAX)   NULL,
    [Description] NVARCHAR (MAX)   NULL,
    CONSTRAINT [PK_Encounters] PRIMARY KEY CLUSTERED ([EncounterId] ASC),
    CONSTRAINT [FK_Encounters_Companies_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Companies] ([CompanyId])
);


GO
CREATE NONCLUSTERED INDEX [IX_Encounters_CompanyId]
    ON [dbo].[Encounters]([CompanyId] ASC);

