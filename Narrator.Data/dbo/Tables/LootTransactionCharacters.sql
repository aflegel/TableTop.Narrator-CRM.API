CREATE TABLE [dbo].[LootTransactionCharacters]
(
	[LootId] UNIQUEIDENTIFIER NOT NULL , 
    [TransactionId] UNIQUEIDENTIFIER NOT NULL, 
    [CharacterId] UNIQUEIDENTIFIER NOT NULL, 
    [Quantity] INT NOT NULL, 
    PRIMARY KEY ([LootId], [TransactionId], [CharacterId]),
	CONSTRAINT [FK_LootTransactionCharacters_Loots] FOREIGN KEY ([LootId]) REFERENCES [Loots]([LootId]),
	CONSTRAINT [FK_LootTransactionCharacters_Transactions] FOREIGN KEY ([TransactionId]) REFERENCES [Transactions]([TransactionId]),
	CONSTRAINT [FK_LootTransactionCharacters_Characters] FOREIGN KEY ([CharacterId]) REFERENCES [Characters]([CharacterId])
)
