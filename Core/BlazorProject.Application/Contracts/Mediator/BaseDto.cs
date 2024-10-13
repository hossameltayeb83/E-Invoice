using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Application.Contracts.Mediator
{
	
	public class ItemDto 
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Code { get; set; }
		public decimal DefaultAmount { get; set; }
	}
	public class ItemWriteDto
	{
		public string Name { get; set; }
		public string Code { get; set; }
		public decimal DefaultAmount { get; set; }
	}
	public class TaxDto 
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Code { get; set; }
		public decimal DefaultRate { get; set; }
	}
	public class TaxWriteDto
	{
		public string Name { get; set; }
		public string Code { get; set; }
		public decimal DefaultRate { get; set; }
	}
}
