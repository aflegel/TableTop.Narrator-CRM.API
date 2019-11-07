CREATE TABLE [dbo].[Transactions] (
    [TransactionId] UNIQUEIDENTIFIER NOT NULL,
    [Description]   NVARCHAR (MAX)   NULL,
    CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED ([TransactionId] ASC)
);

