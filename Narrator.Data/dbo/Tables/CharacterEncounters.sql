CREATE TABLE [dbo].[CharacterEncounters] (
    [CharacterId] UNIQUEIDENTIFIER NOT NULL,
    [EncounterId] UNIQUEIDENTIFIER NOT NULL,
    [Shares]      INT              NOT NULL,
    CONSTRAINT [PK_CharacterEncounters] PRIMARY KEY CLUSTERED ([CharacterId] ASC, [EncounterId] ASC),
    CONSTRAINT [FK_CharacterEncounters_Characters_CharacterId] FOREIGN KEY ([CharacterId]) REFERENCES [dbo].[Characters] ([CharacterId]) ON DELETE CASCADE,
    CONSTRAINT [FK_CharacterEncounters_Encounters_EncounterId] FOREIGN KEY ([EncounterId]) REFERENCES [dbo].[Encounters] ([EncounterId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_CharacterEncounters_EncounterId]
    ON [dbo].[CharacterEncounters]([EncounterId] ASC);

