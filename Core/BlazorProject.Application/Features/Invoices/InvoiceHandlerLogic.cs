using BlazorProject.Application.Contracts.Infrastructre;
using BlazorProject.Application.Contracts.Mediator;
using BlazorProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Application.Features.Invoices
{
    internal class InvoiceHandlerLogic : IHandlerCustomLogic<Invoice>, ICustomGetAllLogic<Invoice, InvoiceDto>, ICustomCreateLogic<Invoice>, ICustomGetOneLogic<Invoice>, ICustomUpdateLogic<Invoice>
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

        public async Task<IReadOnlyList<Invoice>> GetAllLogic(InvoiceDto searchCriteria)
        {
			return await _invoiceRepository.GetInvoices(searchCriteria);
		}

        public async Task<Invoice?> GetOneLogic(int id)
        {
			return await _invoiceRepository.GetInvoiceWithIncludes(id);
		}

		public void UpdateLogic(Invoice entity)
		{
			CreateLogic(entity);
		}
	}
}
