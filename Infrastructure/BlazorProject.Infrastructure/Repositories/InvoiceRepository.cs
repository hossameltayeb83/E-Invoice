using BlazorProject.Application.Contracts.Infrastructre;
using BlazorProject.Application.Features.Invoices;
using BlazorProject.Application.Features.Items;
using BlazorProject.Domain.Entities;
using BlazorProject.Domain.Enums;
using BlazorProject.Infrastructure.Data;
using BlazorProject.Shared.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
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
			if (searchCriteria.CustomerName != null)
			{
				query = query.Where(e => e.Customer.Name.Contains(searchCriteria.CustomerName));
			}
			if (searchCriteria.Type != null)
			{
				var value = (int)searchCriteria.Type;
				query = query.Where(e => e.Type== (Domain.Enums.InvoiceType)value);
			}


			return await base.GetAllAsync(query, page, pageSize);
		}

		public async ValueTask<Invoice?> GetInvoiceWithIncludes(int invoiceId)
		{
			return await _context.Invoices
				.Include(e=>e.Customer)
				.Include(e=>e.InvoiceLines)
				.ThenInclude(e=>e.InvoiceLineTaxes)
				.FirstOrDefaultAsync(e=>e.Id==invoiceId);
		}

        public async Task UpdateInvoice(Invoice invoice)
        {
           var entity= await GetInvoiceWithIncludes(invoice.Id);
			_context.Entry(entity).State=EntityState.Detached;
		   var orgTaxes= entity.InvoiceLines.SelectMany(e=>e.InvoiceLineTaxes);
			var orgLines = entity.InvoiceLines;
		   var newTaxes= invoice.InvoiceLines.SelectMany(e=>e.InvoiceLineTaxes).Select(e => e.Id);
			var deletedtax = orgTaxes.Where(e => !newTaxes.Contains(e.Id));
            foreach (var tax in deletedtax)
            {
                _context.Entry(tax).State = EntityState.Deleted;
            }
            var newLines = invoice.InvoiceLines.Select(e => e.Id);
			var deletetdlines = orgLines.Where(e => !newLines.Contains(e.Id));
			foreach(var line in deletetdlines)
			{
                _context.Entry(line).State = EntityState.Deleted;
            }
        }
    }
}
