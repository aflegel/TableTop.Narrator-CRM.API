using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Narrator.Models;

namespace Narrator.Services
{
	public class Repository: IRepository
	{
		private IConfiguration Configuration { get; }

		public Repository(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public async Task<T> FetchFirst<T>()
		{
			using var connection = new SqlConnection(Configuration.GetConnectionString("AdventureCompany"));

			return await connection.QueryFirstAsync<T>("SELECT TOP 1 Description FROM Encounter");
		}

		public async Task<long> Insert<T>(T item) where T : Encounter
		{
			using var connection = new SqlConnection(Configuration.GetConnectionString("AdventureCompany"));

			return await connection.InsertAsync(item);
		}
	}
}
