using BlazorProject.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Domain.Entities
{
	public class InvoiceLineTax : BaseEntity
	{
		public InvoiceLine InvoiceLine { get; set; }
		public int InvoiceLineId { get; set; }
		public Tax Tax { get; set; }
		public int TaxId { get; set; }
		public string TaxName { get; set; }
		public decimal TaxRate { get; set; }
		public decimal Amount { get; set; }
	}
}
