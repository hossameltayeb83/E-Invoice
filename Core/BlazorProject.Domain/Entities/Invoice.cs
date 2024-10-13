using BlazorProject.Domain.Common;
using BlazorProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Domain.Entities
{
	public class Invoice : AuditableEntity
	{
		public InvoiceType Type { get; set; }
		public string Code { get; set; }
		public decimal NetAmount { get; set; }
		public Customer Customer { get; set; }
		public IReadOnlyCollection<InvoiceLine> InvoiceLines { get; set; }
	}
}
