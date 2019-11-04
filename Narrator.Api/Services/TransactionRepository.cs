using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Narrator.Models;

namespace Narrator.Services
{
	public class TransactionRepository: IRepository<Transaction>
	{ 
		private IConfiguration Configuration { get; }

		public TransactionRepository(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public async Task<Transaction> Select()
		{
			using var connection = new SqlConnection(Configuration.GetConnectionString("AdventureCompany"));

			var trans = await connection.QueryFirstAsync<Transaction>("SELECT TOP 1 * FROM Transactions WHERE TransactionID = '83F023E9-B743-4525-97B8-D6C5341302FD'");
			var transChar = await connection.QueryAsync<LootTransactionCharacter>("SELECT TOP 10 * FROM Transactions WHERE TransactionID = '83F023E9-B743-4525-97B8-D6C5341302FD'");
			var transEnc = await connection.QueryAsync<TransactionLootEncounter>("SELECT TOP 10 * FROM Transactions WHERE TransactionID = '83F023E9-B743-4525-97B8-D6C5341302FD'");

			trans.TransactionLootCharacters.AddRange(transChar);
			trans.TransactionLootEncounters.AddRange(transEnc);

			return trans;// await connection.QueryFirstAsync<Transaction>("SELECT TOP 1 * FROM Transactions WHERE TransactionID = '83F023E9-B743-4525-97B8-D6C5341302FD'");
		}

		public async Task<long> Insert(Transaction item)
		{
			using var connection = new SqlConnection(Configuration.GetConnectionString("AdventureCompany"));

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
