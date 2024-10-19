﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Shared.Dtos
{
    public class InvoiceDto : IDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string? Code { get; set; }
        public decimal NetAmount { get; set; }
        public List<InvoiceLineDto>? InvoiceLines { get; set; }

        public string ToQueryParameters()
        {
            throw new NotImplementedException();
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
