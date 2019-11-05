using System.Threading.Tasks;

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
