using BlazorProject.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Domain.Entities
{
	public class Customer : BaseEntity
	{
		public string Name { get; set; }
		public IReadOnlyCollection<Invoice> Invoices { get; set; }
		public string Code { get ; set ; }
	}
}
