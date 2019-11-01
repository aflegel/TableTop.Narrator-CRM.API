using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Narrator.Models;

namespace Narrator.Services
{
	public class CharacterRepository<T> : IRepository where T : Character
	{
		private IConfiguration Configuration { get; }

		private SqlConnection Connection => new SqlConnection(Configuration.GetConnectionString("AdventureCompany"));

		public CharacterRepository(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public async Task<T> FetchFirst<T>()
		{
			using var connection = Connection;

			return await connection.QueryFirstAsync<T>("SELECT TOP 1 * FROM Characters");
		}

		public async Task<long> Insert<T>(T item)
		{
			using var connection = Connection;

			return await connection.InsertAsync(item as Character);
		}

		public bool MatchType<T>() => typeof(T) == typeof(Character);
	}
}
