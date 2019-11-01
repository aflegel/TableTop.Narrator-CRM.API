CREATE TABLE [dbo].[LootTransactionEncounters]
(
	[LootId] UNIQUEIDENTIFIER NOT NULL , 
    [TransactionId] UNIQUEIDENTIFIER NOT NULL, 
    [EncounterId] UNIQUEIDENTIFIER NOT NULL, 
    [Quantity] INT NOT NULL, 
    PRIMARY KEY ([LootId], [TransactionId], [EncounterId]),
	CONSTRAINT [FK_LootTransactionEncounters_Loots] FOREIGN KEY ([LootId]) REFERENCES [Loots]([LootId]),
	CONSTRAINT [FK_LootTransactionEncounters_Transactions] FOREIGN KEY ([TransactionId]) REFERENCES [Transactions]([TransactionId]),
	CONSTRAINT [FK_LootTransactionEncounters_Encounters] FOREIGN KEY ([EncounterId]) REFERENCES [Encounters]([EncounterId])
)
