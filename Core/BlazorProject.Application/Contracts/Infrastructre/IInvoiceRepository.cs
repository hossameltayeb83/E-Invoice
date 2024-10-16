﻿using BlazorProject.Application.Features.Invoices;
using BlazorProject.Application.Features.Items;
using BlazorProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Application.Contracts.Infrastructre
{
	public interface IInvoiceRepository
	{
		Task<IReadOnlyList<Invoice>> GetInvoices(InvoiceDto searchCriteria);

		ValueTask<Invoice?> GetInvoiceWithIncludes(int invoiceId);
	}
}
