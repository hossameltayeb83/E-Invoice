using AutoMapper;
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
			
		}
	}
}
