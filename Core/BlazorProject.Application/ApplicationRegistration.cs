using BlazorProject.Application.Contracts.Mediator;
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
				,new EntityTypes { Entity = typeof(Tax), ReadDto = typeof(TaxDto), WriteDto = typeof(TaxWriteDto) }});
			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
			return services;

		}
		public static void AddRequestHandlers(this IServiceCollection services,List<EntityTypes> types)
		{
			
			foreach (var type in types)
			{
				var requestHandlerType = typeof(IRequestHandler<,>).MakeGenericType(
										typeof(GetAllQuery<,>).MakeGenericType(type.Entity, type.ReadDto),
										typeof(BaseResponse<>).MakeGenericType(typeof(List<>).MakeGenericType(type.ReadDto))
									);

				// Create the generic type for GetAllQueryHandler<typ, TaxDto>
				var requestHandlerImplType = typeof(GetAllQueryHandler<,>).MakeGenericType(type.Entity, type.ReadDto);

				// Register the service using reflection
				services.AddTransient(requestHandlerType, requestHandlerImplType);

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
