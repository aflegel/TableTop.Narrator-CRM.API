CREATE TABLE [dbo].[LootTransactionCharacters] (
    [LootId]        UNIQUEIDENTIFIER NOT NULL,
    [TransactionId] UNIQUEIDENTIFIER NOT NULL,
    [CharacterId]   UNIQUEIDENTIFIER NOT NULL,
    [Quantity]      INT              NOT NULL,
    CONSTRAINT [PK_LootTransactionCharacters] PRIMARY KEY CLUSTERED ([LootId] ASC, [TransactionId] ASC, [CharacterId] ASC),
    CONSTRAINT [FK_LootTransactionCharacters_Characters_CharacterId] FOREIGN KEY ([CharacterId]) REFERENCES [dbo].[Characters] ([CharacterId]) ON DELETE CASCADE,
    CONSTRAINT [FK_LootTransactionCharacters_Loots_LootId] FOREIGN KEY ([LootId]) REFERENCES [dbo].[Loots] ([LootId]) ON DELETE CASCADE,
    CONSTRAINT [FK_LootTransactionCharacters_Transactions_TransactionId] FOREIGN KEY ([TransactionId]) REFERENCES [dbo].[Transactions] ([TransactionId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_LootTransactionCharacters_CharacterId]
    ON [dbo].[LootTransactionCharacters]([CharacterId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_LootTransactionCharacters_TransactionId]
    ON [dbo].[LootTransactionCharacters]([TransactionId] ASC);

