using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Application.Contracts
{
	public interface IRepository<T> where T : class
	{
		ValueTask<T?> GetByIdAsync(int id);
		Task<IReadOnlyList<T>> ListAllAsync();
		Task<int> AddAsync(T entity);
		Task<bool> UpdateAsync(T entity);
		Task<bool> DeleteAsync(T entity);
	}
}
