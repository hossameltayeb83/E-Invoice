using AutoMapper;
using BlazorProject.Domain.Entities;
using BlazorProject.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Application.Features.Customers
{
	internal class CustomerProfile : Profile
	{
        public CustomerProfile()
        {
			CreateMap<Customer, CustomerDto>().ReverseMap();
		}
	}
}
