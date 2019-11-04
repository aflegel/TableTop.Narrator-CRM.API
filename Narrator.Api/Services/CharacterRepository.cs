using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Narrator.Models;

namespace Narrator.Services
{
	public class CharacterRepository : IRepository<Character>
	{
		private IConfiguration Configuration { get; }

		private SqlConnection Connection => new SqlConnection(Configuration.GetConnectionString("AdventureCompany"));

		public CharacterRepository(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public async Task<Character> Select()
		{
			using var connection = Connection;

			return await connection.QueryFirstAsync<Character>("SELECT TOP 1 * FROM Characters");
		}

		public async Task<long> Insert(Character item)
		{
			using var connection = Connection;

			return await connection.InsertAsync(item);
		}

		public async Task<bool> Update(Character item)
		{
			using var connection = new SqlConnection(Configuration.GetConnectionString("AdventureCompany"));

			return await connection.UpdateAsync(item);
		}

		public async Task<bool> Delete(Character item)
		{
			using var connection = new SqlConnection(Configuration.GetConnectionString("AdventureCompany"));

			return await connection.DeleteAsync(item);
		}
	}
}
