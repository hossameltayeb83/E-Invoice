using BlazorProject.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Domain.Entities
{
	public class Tax : BaseEntity
	{
		public string Name { get; set; }
		public string Code { get; set; }
		public decimal? DefaultRate { get; set; }
        public IReadOnlyCollection<InvoiceLineTax> InvoiceLineTaxes { get; set; }
    }
}
