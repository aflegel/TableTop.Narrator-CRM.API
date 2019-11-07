CREATE TABLE [dbo].[LootTransactionEncounters] (
    [LootId]        UNIQUEIDENTIFIER NOT NULL,
    [TransactionId] UNIQUEIDENTIFIER NOT NULL,
    [EncounterId]   UNIQUEIDENTIFIER NOT NULL,
    [Quantity]      INT              NOT NULL,
    CONSTRAINT [PK_LootTransactionEncounters] PRIMARY KEY CLUSTERED ([LootId] ASC, [TransactionId] ASC, [EncounterId] ASC),
    CONSTRAINT [FK_LootTransactionEncounters_Encounters_EncounterId] FOREIGN KEY ([EncounterId]) REFERENCES [dbo].[Encounters] ([EncounterId]) ON DELETE CASCADE,
    CONSTRAINT [FK_LootTransactionEncounters_Loots_LootId] FOREIGN KEY ([LootId]) REFERENCES [dbo].[Loots] ([LootId]) ON DELETE CASCADE,
    CONSTRAINT [FK_LootTransactionEncounters_Transactions_TransactionId] FOREIGN KEY ([TransactionId]) REFERENCES [dbo].[Transactions] ([TransactionId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_LootTransactionEncounters_EncounterId]
    ON [dbo].[LootTransactionEncounters]([EncounterId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_LootTransactionEncounters_TransactionId]
    ON [dbo].[LootTransactionEncounters]([TransactionId] ASC);

