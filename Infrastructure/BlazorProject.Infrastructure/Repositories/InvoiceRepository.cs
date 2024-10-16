﻿using BlazorProject.Application.Contracts.Infrastructre;
using BlazorProject.Application.Features.Invoices;
using BlazorProject.Application.Features.Items;
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
	internal class InvoiceRepository : IInvoiceRepository
	{
		private readonly ProjectContext _context;
		public InvoiceRepository(ProjectContext context) { _context = context; }

		public async Task<IReadOnlyList<Invoice>> GetInvoices(InvoiceDto searchCriteria)
		{
			var query = _context.Invoices.AsQueryable();
			if (searchCriteria.Id != 0)
			{
				query = query.Where(e => e.Id == searchCriteria.Id);
			}
			if (searchCriteria.Code != null)
			{
				query = query.Where(e => e.Code == searchCriteria.Code);
			}
			return await query.ToListAsync();
		}

		public async ValueTask<Invoice?> GetInvoiceWithIncludes(int invoiceId)
		{
			return await _context.Invoices.Include(e=>e.InvoiceLines).ThenInclude(e=>e.InvoiceLineTaxes).FirstOrDefaultAsync(e=>e.Id==invoiceId);
		}
	}
}
