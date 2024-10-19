using BlazorProject.Application.Contracts.Infrastructre;
using BlazorProject.Application.Features.Invoices;
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
	internal class InvoiceRepository : BaseRepository<Invoice>, IInvoiceRepository
	{
		public InvoiceRepository(ProjectContext context) : base(context) { }


		public async Task<(IReadOnlyList<Invoice>, int)> GetInvoices(InvoiceDto searchCriteria, int page, int pageSize)
		{
			var query = _context.Invoices.Include(e=>e.Customer).AsQueryable();
			if (searchCriteria.Id != 0)
			{
				query = query.Where(e => e.Id == searchCriteria.Id);
			}
			if (searchCriteria.Code != null)
			{
				query = query.Where(e => e.Code == searchCriteria.Code);
			}
			return await base.GetAllAsync(query, page, pageSize);
		}

		public async ValueTask<Invoice?> GetInvoiceWithIncludes(int invoiceId)
		{
			return await _context.Invoices
				.Include(e=>e.InvoiceLines)
				.ThenInclude(e=>e.InvoiceLineTaxes)
				.FirstOrDefaultAsync(e=>e.Id==invoiceId);
		}
	}
}
