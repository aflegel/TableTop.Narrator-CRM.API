CREATE PROCEDURE [dbo].[GetRemainingCount]
	@EncounterId uniqueidentifier,
	@LootId uniqueidentifier
AS
	SET NOCOUNT ON;

	SELECT SUM(LootTransactionEncounters.Quantity) as RemainingLoot
	FROM LootTransactionEncounters
	WHERE EncounterId = @EncounterId AND LootId = @LootId
	GROUP BY LootId
RETURN
