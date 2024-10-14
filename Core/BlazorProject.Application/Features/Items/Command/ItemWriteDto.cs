using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Application.Features.Items.Command
{
	public class ItemWriteDto
	{
		public string Name { get; set; }
		public string Code { get; set; }
		public decimal DefaultAmount { get; set; }
	}
}
