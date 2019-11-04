using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Narrator.Services
{
	public interface IRepository<T>
	{
		Task<T> Select();
		Task<long> Insert(T item);
		Task<bool> Delete(T item);
		Task<bool> Update(T item);

	}
}
