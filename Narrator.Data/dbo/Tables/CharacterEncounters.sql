CREATE TABLE [dbo].[CharacterEncounters] (
    [CharacterId] UNIQUEIDENTIFIER NOT NULL,
    [EncounterId] UNIQUEIDENTIFIER NOT NULL,
    [Shares]      INT              NOT NULL,
    CONSTRAINT [PK_CharacterEncounters] PRIMARY KEY CLUSTERED ([CharacterId] ASC, [EncounterId] ASC),
	CONSTRAINT [FK_CharacterEncounters_Characters] FOREIGN KEY ([CharacterId]) REFERENCES [Characters]([CharacterId]),
	CONSTRAINT [FK_CharacterEncounters_Encounters] FOREIGN KEY ([EncounterId]) REFERENCES [Encounters]([EncounterId])
);

