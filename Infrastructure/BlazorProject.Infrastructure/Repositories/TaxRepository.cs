using BlazorProject.Application.Contracts.Infrastructre;
using BlazorProject.Application.Features.Items;
using BlazorProject.Application.Features.Taxes;
using BlazorProject.Domain.Entities;
using BlazorProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Infrastructure.Repositories
{
	internal class TaxRepository : ITaxRepository
	{
		private readonly ProjectContext _context;
		public TaxRepository(ProjectContext context) { _context = context; }

		public async Task<IReadOnlyList<Tax>> GetTaxes(TaxDto searchCriteria)
		{
			var query = _context.Taxes.AsQueryable();
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
			return await query.ToListAsync();
		}
	}
}
