using Azure;
using BlazorProject.Application.Contracts;
using BlazorProject.Domain.Common;
using BlazorProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Infrastructure.Repositories
{
	internal class BaseRepository<T> : IRepository<T> where T : BaseEntity
	{
		protected readonly ProjectContext _context;
		public BaseRepository(ProjectContext context) { _context = context; }
		public async Task<int> AddAsync(T entity)
		{
			await _context.Set<T>().AddAsync(entity);
			await _context.SaveChangesAsync();
			return entity.Id;
		}

		public async Task<bool> DeleteAsync(T entity)
		{
			_context.Set<T>().Remove(entity);
			return await _context.SaveChangesAsync() > 0;
		}

		public async ValueTask<T?> GetByIdAsync(int id)
		{
			return await _context.Set<T>().FindAsync(id);
		}

		public async Task<(IReadOnlyList<T>, int)> GetAllAsync(int page, int pageSize)
		{
			var result = await _context.Set<T>()
				.GroupBy(e => 1)
				.Select(e => new
							{
								Count = e.Count(),
								Items = e.Skip((page - 1) * pageSize).Take(pageSize).ToList()
							}).FirstOrDefaultAsync();
			return (result.Items, result.Count);
		}

		protected async Task<(IReadOnlyList<T>, int)> GetAllAsync(IQueryable<T> query, int page, int pageSize)
		{
			var result = await query
				.GroupBy(e => 1)
				.Select(e => new
							{
								Count = e.Count(),
								Items = e.Skip((page - 1) * pageSize).Take(pageSize).ToList()
							})
				.FirstOrDefaultAsync();
			return (result.Items, result.Count);
		}
		public async Task<bool> UpdateAsync(T entity)
		{
			_context.Set<T>().Update(entity);
			return await _context.SaveChangesAsync() > 0;
		}

	}
}
