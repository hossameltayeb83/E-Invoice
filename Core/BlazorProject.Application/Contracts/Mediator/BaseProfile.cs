﻿using AutoMapper;
using BlazorProject.Application.Features.Customers;
using BlazorProject.Application.Features.Invoices;
using BlazorProject.Application.Features.Items;
using BlazorProject.Application.Features.Taxes;
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
			CreateMap<Tax, TaxDto>().ReverseMap();
			CreateMap<Customer, CustomerDto>().ReverseMap();
			CreateMap<Invoice, InvoiceDto>().ReverseMap();
			CreateMap<InvoiceLine, InvoiceLineDto>().ReverseMap();
			CreateMap<InvoiceLineTax, InvoiceLineTaxDto>().ReverseMap();
		}
	}
}
