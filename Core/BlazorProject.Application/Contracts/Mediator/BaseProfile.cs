using AutoMapper;
using BlazorProject.Application.Features.Customers.Command;
using BlazorProject.Application.Features.Customers.Query;
using BlazorProject.Application.Features.Invoices.Command;
using BlazorProject.Application.Features.Invoices.Query;
using BlazorProject.Application.Features.Items.Command;
using BlazorProject.Application.Features.Items.Query;
using BlazorProject.Application.Features.Taxes.Command;
using BlazorProject.Application.Features.Taxes.Query;
using BlazorProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Application.Contracts.Mediator
{
	internal class BaseProfile : Profile
	{
		public BaseProfile()
		{
			CreateMap<Item, ItemDto>().ReverseMap();
			CreateMap<ItemWriteDto, Item>();
			CreateMap<Tax, TaxDto>().ReverseMap();
			CreateMap<TaxWriteDto, Tax>();
			CreateMap<Customer, CustomerDto>().ReverseMap();
			CreateMap<CustomerWriteDto, Customer>();
			CreateMap<Invoice, InvoiceDto>().ReverseMap();
			CreateMap<InvoiceWriteDto, Invoice>();
			CreateMap<InvoiceLine, InvoiceLineDto>().ReverseMap();
			CreateMap<InvoiceLineWriteDto, InvoiceLine>();
			CreateMap<InvoiceLineTax, InvoiceLineTaxDto>().ReverseMap();
			CreateMap<InvoiceLineTaxWriteDto, InvoiceLineTax>();
		}
	}
}
