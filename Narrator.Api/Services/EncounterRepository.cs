using System;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Narrator.Models;

namespace Narrator.Services
{
	public class EncounterRepository: IRepository<Encounter>
	{ 
		private IConfiguration Configuration { get; }

		public EncounterRepository(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public async Task<Encounter> Select()
		{
			using var connection = new SqlConnection(Configuration.GetConnectionString("AdventureCompany"));

			return await connection.QueryFirstAsync<Encounter>("SELECT TOP 1 * FROM Encounters");
		}

		public async Task<long> Insert(Encounter item)
		{
			using var connection = new SqlConnection(Configuration.GetConnectionString("AdventureCompany"));

			return await connection.InsertAsync(item);
		}

		public async Task<bool> Update(Encounter item)
		{
			using var connection = new SqlConnection(Configuration.GetConnectionString("AdventureCompany"));

			return await connection.UpdateAsync(item);
		}

		public async Task<bool> Delete(Encounter item)
		{
			using var connection = new SqlConnection(Configuration.GetConnectionString("AdventureCompany"));

			return await connection.DeleteAsync(item);
		}
	}
}
