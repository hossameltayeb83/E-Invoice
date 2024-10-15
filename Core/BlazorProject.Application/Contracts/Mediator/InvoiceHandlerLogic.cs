using BlazorProject.Application.Contracts.Infrastructre;
using BlazorProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Application.Contracts.Mediator
{
	internal class InvoiceHandlerLogic : IHandlerCustomLogic<Invoice>
	{
		private readonly IInvoiceRepository _invoiceRepository;
        public InvoiceHandlerLogic(IInvoiceRepository invoiceRepository)
        {
			_invoiceRepository = invoiceRepository;
		}
		public void CreateLogic(Invoice entity)
		{
			foreach (var invoiceLine in entity.InvoiceLines)
			{
				invoiceLine.Total = invoiceLine.Amount * invoiceLine.Quantity;
				invoiceLine.ItemNetAmount = invoiceLine.Total;
				foreach (var invoiceLineTax in invoiceLine.InvoiceLineTaxes)
				{
					invoiceLineTax.Amount = invoiceLine.Amount * (invoiceLineTax.TaxRate / 100);
					invoiceLine.ItemNetAmount += invoiceLineTax.Amount;
				}
				entity.NetAmount += invoiceLine.ItemNetAmount;
			}
		}

		public void DelteLogic(Invoice entity)
		{
			throw new NotImplementedException();
		}

		public void GetAllLogic(Invoice entity)
		{
			throw new NotImplementedException();
		}

		public async Task<Invoice?> GetOneLogic(int Id)
		{
			return await _invoiceRepository.GetInvoiceWithIncludes(Id);
		}

		public void UpdateLogic(Invoice entity)
		{
			throw new NotImplementedException();
		}
	}
}
