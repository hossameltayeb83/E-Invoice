using BlazorProject.Application.Contracts.Infrastructre;
using BlazorProject.Application.Features.Customers;
using BlazorProject.Application.Features.Items;
using BlazorProject.Domain.Entities;
using BlazorProject.Infrastructure.Data;
using BlazorProject.Shared.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Infrastructure.Repositories
{
	internal class ItemRepository : BaseRepository<Item>,IItemRepository
	{
		public ItemRepository(ProjectContext context) : base(context) { }

		public async Task<(IReadOnlyList<Item>, int)> GetItems(ItemDto searchCriteria, int page, int pageSize)
		{
			var query = _context.Items.AsQueryable();
			if (searchCriteria.Id != 0)
			{
				query = query.Where(e => e.Id == searchCriteria.Id);
			}
			if (searchCriteria.Code != null)
			{
				query = query.Where(e => e.Code == searchCriteria.Code);
			}
			if (searchCriteria.Name != null)
			{
				query = query.Where(e => e.Name.Contains(searchCriteria.Name));
			}
			return await base.GetAllAsync(query, page, pageSize);
		}
	}
}
