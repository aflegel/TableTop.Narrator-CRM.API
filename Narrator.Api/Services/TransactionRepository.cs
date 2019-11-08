using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Narrator.Models;

namespace Narrator.Services
{
	public static class TransactionRepository
	{
		public static async Task<Transaction> Select(this CompanyRepository repository)
		{
			var transId = Guid.Parse("83F023E9-B743-4525-97B8-D6C5341302FD");

			var transaction = await repository.Transactions.AsAsyncQueryable().Where(w => w.TransactionId == transId).FirstOrDefaultAsync();

			transaction.LootTransactionCharacters = await repository.LootTransactionCharacters.AsAsyncQueryable().Where(w => w.TransactionId == transId).ToListAsync();
			transaction.LootTransactionEncounters = await repository.LootTransactionEncounters.AsAsyncQueryable().Where(w => w.TransactionId == transId).ToListAsync();

			return transaction;
		}

		private static int GetRemainingCount(this CompanyRepository repository, Guid encounterId, Guid lootId) => repository.GetRemainingCount(encounterId, lootId);

		public static Transaction Insert(this CompanyRepository repository, Transaction item)
		{
			// quantity must not be 0
			//GetRemainingCount + quantity must not be less than 0
			var lootTransactions = item.LootTransactionEncounters.GroupBy(i => new { i.LootId, i.EncounterId });
			var lootRemaining = lootTransactions.Select(s => (repository.GetRemainingCount(s.Key.LootId, s.Key.EncounterId)) <= 0)
				.Any(t => !t);

			//var remaining = await GetRemainingCount(connection, Guid.Parse("374665DC-9076-4558-B106-E9A703D1F384"), Guid.Parse("D422CC1B-7B1A-484A-AC13-B1DD2B4C1E1E"));
			var result = repository.Transactions.Add(item);
			return result.Entity;
		}
	}
}
