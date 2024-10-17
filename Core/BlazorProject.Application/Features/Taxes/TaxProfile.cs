using AutoMapper;
using BlazorProject.Application.Features.Customers;
using BlazorProject.Domain.Entities;
using BlazorProject.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Application.Features.Taxes
{
	internal class TaxProfile : Profile
	{
        public TaxProfile()
        {
			CreateMap<Tax, TaxDto>().ReverseMap();
		}
    }
}
