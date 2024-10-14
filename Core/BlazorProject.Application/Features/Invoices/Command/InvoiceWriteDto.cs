using BlazorProject.Application.Contracts.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Application.Features.Invoices.Command
{
	public class InvoiceWriteDto
	{
		public string Code { get; set; }
		public string CustomerId { get; set; }
		public List<InvoiceLineWriteDto> InvoiceLines { get; set; }
	}
	
	public class InvoiceLineWriteDto
	{
		public int ItemId { get; set; }
		public string ItemName { get; set; }
		public int Quantity { get; set; }
		public decimal Amount { get; set; }
		public List<InvoiceLineTaxWriteDto> InvoiceLineTaxes { get; set; }
	}
	
	public class InvoiceLineTaxWriteDto
	{
		public int TaxId { get; set; }
		public string TaxName { get; set; }
		public decimal TaxRate { get; set; }
	}
}
