using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Shared.Dtos
{
    public class TaxDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public decimal DefaultRate { get; set; }
    }
}
