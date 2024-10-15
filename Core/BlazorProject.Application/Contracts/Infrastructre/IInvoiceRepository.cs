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
		ValueTask<Invoice?> GetInvoiceWithIncludes(int invoiceId);
	}
}
