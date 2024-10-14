using BlazorProject.Application.Contracts.Mediator;
using BlazorProject.Application.Features.Invoices.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Application.Features.Invoices.Query
{
	public class InvoiceDto
	{
		public int Id { get; set; }
		public string CustomerId { get; set; }
		public string Code { get; set; }
		public decimal NetAmount { get; set; }
		public List<InvoiceLineDto> InvoiceLines { get; set; }
	}
	public class InvoiceLineDto
	{
		public int InvoiceLineId { get; set; }
		public int InvoiceId { get; set; }
		public int ItemId { get; set; }
		public string ItemName { get; set; }
		public decimal Total { get; set; }
		public int Quantity { get; set; }
		public decimal Amount { get; set; }
		public List<InvoiceLineTaxDto> InvoiceLineTaxes { get; set; }
	}
	public class InvoiceLineTaxDto
	{
		public int InvoiceLineTaxId { get; set; }
		public int InvoiceLineId { get; set; }
		public int TaxId { get; set; }
		public string TaxName { get; set; }
		public decimal TaxRate { get; set; }
		public decimal Amount { get; set; }
	}
}
