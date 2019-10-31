using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

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
	}
}
