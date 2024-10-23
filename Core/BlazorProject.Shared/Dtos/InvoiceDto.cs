using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlazorProject.Shared.Dtos
{
    public enum InvoiceType
    {
		sale=0, refund=1
	}
    public class InvoiceDto : IDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? Code { get; set; }
        public decimal NetAmount { get; set; }
        public DateTime DateTimeIssued { get; set; }
        public InvoiceType? Type { get; set; }
        public List<InvoiceLineDto>? InvoiceLines { get; set; }

        public string ToQueryParameters()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("?");
            if (Code != null)
                sb.Append($"Code={Code}");
            if (CustomerName != null)
                if (sb.Length > 1)
                    sb.Append($"&CustomerName={CustomerName}");
                else
                    sb.Append($"CustomerName={CustomerName}");
			if (Type != null)
            {
                var value=(int)Type;
				if (sb.Length > 1)
					sb.Append($"&Type={value}");
				else
					sb.Append($"Type={value}");
			}
				
			return sb.ToString();
        }
    }
    public class InvoiceLineDto
    {
        public int InvoiceLineId { get; set; }
        public int InvoiceId { get; set; }
        public int ItemId { get; set; }
        public string? ItemName { get; set; }
        public decimal Total { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public decimal ItemNetAmount { get; set; }
        public List<InvoiceLineTaxDto>? InvoiceLineTaxes { get; set; }
    }
    public class InvoiceLineTaxDto
    {
        public int InvoiceLineTaxId { get; set; }
        public int InvoiceLineId { get; set; }
        public int TaxId { get; set; }
        public string? TaxName { get; set; }
        public decimal TaxRate { get; set; }
        public decimal Amount { get; set; }
    }
}
