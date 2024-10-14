using BlazorProject.Application.Common.Mediator.Command;
using BlazorProject.Application.Common.Mediator.Query;
using BlazorProject.Application.Contracts.Mediator;
using BlazorProject.Application.Features.Customers.Command;
using BlazorProject.Application.Features.Customers.Query;
using BlazorProject.Application.Features.Invoices.Command;
using BlazorProject.Application.Features.Invoices.Query;
using BlazorProject.Application.Features.Items.Command;
using BlazorProject.Application.Features.Items.Query;
using BlazorProject.Application.Features.Taxes.Command;
using BlazorProject.Application.Features.Taxes.Query;
using BlazorProject.Application.Responses;
using BlazorProject.Domain.Entities;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Application
{
	public class EntityTypes
	{
		public Type Entity { get; set; }
		public Type ReadDto { get; set; }
		public Type WriteDto { get; set; }
        
    }
	public static class ApplicationRegistration
	{
		public static IServiceCollection AddApplicationServies(this IServiceCollection services)
		{
			services.AddMediatR(config =>
			
				config.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
			);
			//services.AddTransient<IRequestHandler<GetAllQuery<Item, ItemDto>, BaseResponse<List<ItemDto>>>, GetAllQueryHandler<Item, ItemDto>>();
			//services.AddTransient<IRequestHandler<GetOneQuery<Item, ItemDto>, BaseResponse<ItemDto>>, GetOneQueryHandler<Item, ItemDto>>();
			//services.AddTransient<IRequestHandler<CreateCommand<Item, ItemWriteDto>, BaseResponse<int>>, CreateCommandHandler<Item, ItemWriteDto>>();
			//services.AddTransient<IRequestHandler<UpdateCommand<Item, ItemDto>, BaseResponse>, UpdateCommandHandler<Item, ItemDto>>();
			//services.AddTransient<IRequestHandler<DeleteCommand<Item>, BaseResponse>, DeleteCommandHandler<Item>>();
			//services.AddTransient<IRequestHandler<GetAllQuery<Tax, TaxDto>, BaseResponse<List<TaxDto>>>, GetAllQueryHandler<Tax, TaxDto>>();
			//services.AddTransient<IRequestHandler<GetOneQuery<Tax, TaxDto>, BaseResponse<TaxDto>>, GetOneQueryHandler<Tax, TaxDto>>();
			//services.AddTransient<IRequestHandler<CreateCommand<Tax, TaxWriteDto>, BaseResponse<int>>, CreateCommandHandler<Tax, TaxWriteDto>>();
			//services.AddTransient<IRequestHandler<UpdateCommand<Tax, TaxDto>, BaseResponse>, UpdateCommandHandler<Tax, TaxDto>>();
			//services.AddTransient<IRequestHandler<DeleteCommand<Tax>, BaseResponse>, DeleteCommandHandler<Tax>>();
			services.AddRequestHandlers(new List<EntityTypes> {
				new EntityTypes { Entity=typeof(Item),ReadDto=typeof(ItemDto),WriteDto=typeof(ItemWriteDto)}
				,new EntityTypes { Entity = typeof(Tax), ReadDto = typeof(TaxDto), WriteDto = typeof(TaxWriteDto) }
				,new EntityTypes {Entity= typeof(Customer),ReadDto=typeof(CustomerDto),WriteDto=typeof(CustomerWriteDto)}
				,new EntityTypes {Entity= typeof(Invoice),ReadDto=typeof(InvoiceDto),WriteDto=typeof(InvoiceWriteDto)}
			});
			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
			return services;

		}
		public static void AddRequestHandlers(this IServiceCollection services,List<EntityTypes> types)
		{
			var requestInterface = typeof(IRequest<>);
			var assemblytypes = Assembly.GetExecutingAssembly().GetTypes();
			var requestTypes= assemblytypes.Where(type=> type.GetInterfaces().Any(i=> i.IsGenericType&& i.GetGenericTypeDefinition()== requestInterface)).ToList();
			foreach (var type in types)
			{
				foreach(var requestType in requestTypes)
				{
					Type request;
					Type response;
					Type dto = null;
					Type handler;
					if(requestType.GetGenericTypeDefinition() == typeof(GetAllQuery<,>))
					{
						dto = type.ReadDto;
						request = requestType.MakeGenericType(type.Entity, dto);
						response= typeof(BaseResponse<>).MakeGenericType(typeof(List<>).MakeGenericType(type.ReadDto));
						handler = typeof(GetAllQueryHandler<,>);
					}
					else if(requestType.GetGenericTypeDefinition() == typeof(GetOneQuery<,>))
					{
						dto = type.ReadDto;
						request = requestType.MakeGenericType(type.Entity, dto);
						response = typeof(BaseResponse<>).MakeGenericType(type.ReadDto);
						handler = typeof(GetOneQueryHandler<,>);
					}
					else if(requestType.GetGenericTypeDefinition()== typeof(CreateCommand<,>))
					{
						dto = type.WriteDto;
						request = requestType.MakeGenericType(type.Entity, dto);
						response = typeof(BaseResponse<int>);
						handler = typeof(CreateCommandHandler<,>);
					}
					else if (requestType.GetGenericTypeDefinition() == typeof(UpdateCommand<,>))
					{
						dto = type.ReadDto;
						request = requestType.MakeGenericType(type.Entity, dto);
						response = typeof(BaseResponse);
						handler = typeof(UpdateCommandHandler<,>);
					}
					else
					{
						request = requestType.MakeGenericType(type.Entity);
						response = typeof(BaseResponse);
						handler = typeof(DeleteCommandHandler<>);
					}
					//response = typeof(BaseResponse<>).MakeGenericType(typeof(List<>).MakeGenericType(type.ReadDto));
					var requestHandlerType = typeof(IRequestHandler<,>).MakeGenericType(request, response);
					Type requestHandlerImplType;
					if (dto == null)
					{
						 requestHandlerImplType = handler.MakeGenericType(type.Entity);

					}
					else
					{
						requestHandlerImplType = handler.MakeGenericType(type.Entity,dto);
					}
					services.AddTransient(requestHandlerType, requestHandlerImplType);
					//var requestHandlerType = typeof(IRequestHandler<,>).MakeGenericType(
					//						requestType.MakeGenericType(type.Entity, type.ReadDto),
					//						typeof(BaseResponse<>).MakeGenericType(typeof(List<>).MakeGenericType(type.ReadDto))
					//					);
				}

				// Create the generic type for GetAllQueryHandler<typ, TaxDto>
				//var requestHandlerImplType = typeof(GetAllQueryHandler<,>).MakeGenericType(type.Entity, type.ReadDto);

				// Register the service using reflection
				//services.AddTransient(requestHandlerType, requestHandlerImplType);

				//services.AddTransient<IRequestHandler<GetAllQuery<type, TaxDto>, BaseResponse<List<TaxDto>>>, GetAllQueryHandler<type, TaxDto>>();
				//services.AddTransient<IRequestHandler<GetOneQuery<type, TaxDto>, BaseResponse<TaxDto>>, GetOneQueryHandler<type, TaxDto>>();
				//services.AddTransient<IRequestHandler<CreateCommand<type, TaxWriteDto>, BaseResponse<int>>, CreateCommandHandler<type, TaxWriteDto>>();
				//services.AddTransient<IRequestHandler<UpdateCommand<type, TaxDto>, BaseResponse>, UpdateCommandHandler<type, TaxDto>>();
				//services.AddTransient<IRequestHandler<DeleteCommand<Tax>, BaseResponse>, DeleteCommandHandler<Tax>>();
			}
			//var assembly = Assembly.GetExecutingAssembly();

			//// Find all the IRequestHandler implementations in the current assembly
			////var handlerTypes = assembly.GetTypes();
			//var handlerTypes = assembly.GetTypes()
			//	.Where(t => !t.IsAbstract && t.IsGenericTypeDefinition)
			//	.Where(t => t.GetInterfaces().Any(i =>
			//		i.IsGenericType &&
			//		i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>)))
			//	.ToList();
			//var @interface = typeof(IRequestHandler<DeleteCommand<Tax>,BaseResponse>);
			//foreach (var handlerType in handlerTypes)
			//{
			//	// Get the interfaces implemented by the handler
			//	var interfaces = handlerType.GetInterfaces()
			//		.Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>))
			//		.ToList();

			//	foreach (var @interfac in interfaces)
			//	{
			//		// Register the handler with its interface
			//		services.AddTransient(@interfac, handlerType);
			//	}
			//}
		}
	}
}
