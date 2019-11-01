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

		public CharacterRepository(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public async Task<T> FetchFirst<T>()
		{
			using var connection = new SqlConnection(Configuration.GetConnectionString("AdventureCompany"));

			return await connection.QueryFirstAsync<T>("SELECT TOP 1 Description FROM Character");
		}

		public async Task<long> Insert<T>(T item)
		{
			using var connection = new SqlConnection(Configuration.GetConnectionString("AdventureCompany"));

			return await connection.InsertAsync(item as Character);
		}
	}
}
