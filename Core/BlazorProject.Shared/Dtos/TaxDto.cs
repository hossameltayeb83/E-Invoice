using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Shared.Dtos
{
    public class TaxDto :IDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public decimal DefaultRate { get; set; }

        public string ToQueryParameters()
        {
			StringBuilder sb = new StringBuilder();
			sb.Append("?");
			if (Code != null)
				sb.Append($"Code={Code}");
			if (Name != null)
				if (sb.Length > 1)
					sb.Append($"&Name={Name}");
				else
					sb.Append($"Name={Name}");
			return sb.ToString();
		}
    }
}
