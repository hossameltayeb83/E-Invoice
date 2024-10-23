using BlazorProject.Application.Features.Customers;
using BlazorProject.Application.Features.Items;
using BlazorProject.Domain.Entities;
using BlazorProject.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Application.Contracts.Infrastructre
{
	public interface IInvoiceRepository
	{
		Task<(IReadOnlyList<Invoice>, int)> GetInvoices(InvoiceDto searchCriteria, int page, int pageSize);


		ValueTask<Invoice?> GetInvoiceWithIncludes(int invoiceId);

		Task UpdateInvoice(Invoice invoice);
	}
}
