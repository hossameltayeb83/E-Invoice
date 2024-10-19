using AutoMapper;
using BlazorProject.Application.Features.Customers;
using BlazorProject.Application.Features.Items;
using BlazorProject.Application.Features.Taxes;
using BlazorProject.Domain.Entities;
using BlazorProject.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Application.Features.Invoices
{
	internal class InvoiceProfile : Profile
	{
		public InvoiceProfile()
		{
			CreateMap<Invoice, InvoiceDto>().ForMember(dest => dest.CustomerName,option=>option.MapFrom(src=>src.Customer.Name)).ReverseMap();
			CreateMap<InvoiceLine, InvoiceLineDto>().ForMember(dest => dest.InvoiceLineId, option => option.MapFrom(src => src.Id)).ReverseMap();
			CreateMap<InvoiceLineTax, InvoiceLineTaxDto>().ForMember(dest => dest.InvoiceLineTaxId, option => option.MapFrom(src => src.Id)).ReverseMap();
		}
	}
}
