using BlazorProject.Application.Contracts.Mediator;
using BlazorProject.Application.Responses;
using BlazorProject.Domain.Entities;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Application
{
	public static class ApplicationRegistration
	{
		public static IServiceCollection AddApplicationServies(this IServiceCollection services)
		{
			services.AddMediatR(config =>
			
				config.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
			);
			services.AddTransient<IRequestHandler<GetAllQuery<Item,ItemDto>,BaseResponse<List<ItemDto>>>,GetAllQueryHandler<Item,ItemDto>>();
			services.AddTransient<IRequestHandler<GetOneQuery<Item,ItemDto>,BaseResponse<ItemDto>>,GetOneQueryHandler<Item,ItemDto>>();
			services.AddTransient<IRequestHandler<CreateCommand<Item,ItemWriteDto>,BaseResponse<int>>,CreateCommandHandler<Item,ItemWriteDto>>();
			services.AddTransient<IRequestHandler<UpdateCommand<Item, ItemDto>, BaseResponse>, UpdateCommandHandler<Item, ItemDto>>();
			services.AddTransient<IRequestHandler<DeleteCommand<Item>,BaseResponse>,DeleteCommandHandler<Item>>();
			services.AddTransient<IRequestHandler<GetAllQuery<Tax,TaxDto>,BaseResponse<List<TaxDto>>>,GetAllQueryHandler<Tax,TaxDto>>();
			services.AddTransient<IRequestHandler<GetOneQuery<Tax, TaxDto>, BaseResponse<TaxDto>>, GetOneQueryHandler<Tax, TaxDto>>();
			services.AddTransient<IRequestHandler<CreateCommand<Tax, TaxWriteDto>, BaseResponse<int>>, CreateCommandHandler<Tax, TaxWriteDto>>();
			services.AddTransient<IRequestHandler<UpdateCommand<Tax, TaxDto>, BaseResponse>, UpdateCommandHandler<Tax, TaxDto>>();
			services.AddTransient<IRequestHandler<DeleteCommand<Tax>, BaseResponse>, DeleteCommandHandler<Tax>>();
			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
			return services;

		}
	}
}
