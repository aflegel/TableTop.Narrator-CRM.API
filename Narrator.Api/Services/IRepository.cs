using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Narrator.Services
{
	public interface IRepository
	{
		Task<T> FetchFirst<T>();
		Task<long> Insert<T>(T item);
	}
}
