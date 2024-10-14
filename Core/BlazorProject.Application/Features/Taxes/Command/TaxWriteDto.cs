using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Application.Features.Taxes.Command
{
	public class TaxWriteDto
	{
		public string Name { get; set; }
		public string Code { get; set; }
		public decimal DefaultRate { get; set; }
	}
}
