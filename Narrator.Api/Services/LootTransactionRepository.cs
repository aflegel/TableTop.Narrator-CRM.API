using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Narrator.Models;

namespace Narrator.Services
{
	public class LootTransactionRepository : IRepository<Transaction>
	{
		private IConfiguration Configuration { get; }

		public LootTransactionRepository(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public async Task<Transaction> Select()
		{
			using var connection = new SqlConnection(Configuration.GetConnectionString("AdventureCompany"));

			var (transactionTask, transCharacterTask, transEncounterTask) = GetTransactionTasks(connection);

			var transaction = await transactionTask;

			transaction.TransactionLootCharacters = (await transCharacterTask).ToList();
			transaction.TransactionLootEncounters = (await transEncounterTask).ToList();

			return transaction;
		}

		public (Task<Transaction>, Task<IEnumerable<LootTransactionCharacter>>, Task<IEnumerable<LootTransactionEncounter>>) GetTransactionTasks(SqlConnection connection) =>
			(connection.QueryFirstAsync<Transaction>("SELECT TOP 1 * FROM Transactions WHERE TransactionID = '83F023E9-B743-4525-97B8-D6C5341302FD'"),
			connection.QueryAsync<LootTransactionCharacter>("SELECT TOP 10 * FROM Transactions WHERE TransactionID = '83F023E9-B743-4525-97B8-D6C5341302FD'"),
			connection.QueryAsync<LootTransactionEncounter>("SELECT TOP 10 * FROM Transactions WHERE TransactionID = '83F023E9-B743-4525-97B8-D6C5341302FD'"));

		private Task<IEnumerable<int>> GetRemainingCount(SqlConnection connection, Guid encounterId, Guid lootId) => connection.QueryAsync<int>("GetRemainingCount", new { EncounterId = encounterId, LootId = lootId },
				commandType: CommandType.StoredProcedure);

		public async Task<long> Insert(Transaction item)
		{
			using var connection = new SqlConnection(Configuration.GetConnectionString("AdventureCompany"));
			// quantity must not be 0
			//GetRemainingCount + quantity must not be less than 0
			var remaining = await GetRemainingCount(connection, Guid.Parse("374665DC-9076-4558-B106-E9A703D1F384"), Guid.Parse("D422CC1B-7B1A-484A-AC13-B1DD2B4C1E1E"));

			return await connection.InsertAsync(item);
		}

		public async Task<bool> Update(Transaction item)
		{
			using var connection = new SqlConnection(Configuration.GetConnectionString("AdventureCompany"));

			return await connection.UpdateAsync(item);
		}

		public async Task<bool> Delete(Transaction item)
		{
			using var connection = new SqlConnection(Configuration.GetConnectionString("AdventureCompany"));

			return await connection.DeleteAsync(item);
		}
	}
}
