using AutoMapper;
using BlazorProject.Application.Features.Customers;
using BlazorProject.Application.Features.Taxes;
using BlazorProject.Domain.Entities;
using BlazorProject.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Application.Features.Items
{
	internal class ItemProfile:Profile
	{
        public ItemProfile()
        {
			CreateMap<Item, ItemDto>().ReverseMap();
		}
    }
}
