using BlazorProject.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Domain.Entities
{
	public class InvoiceLine : BaseEntity
	{
		public int InvoiceId { get; set; }
		public Invoice Invoice { get; set; }
		public int ItemId { get; set; }
		public Item Item { get; set; }
		public string ItemName { get; set; }
		public int Quantity { get; set; }
		public decimal Amount { get; set; }
		public decimal Total {  get; set; }
		public decimal ItemNetAmount { get; set; }
		public IReadOnlyCollection<InvoiceLineTax> InvoiceLineTaxes { get; set; }
	}
}
