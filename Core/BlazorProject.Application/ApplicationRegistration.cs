using BlazorProject.Application.Common.Mediator.Command;
using BlazorProject.Application.Common.Mediator.Query;
using BlazorProject.Application.Contracts.Mediator;
using BlazorProject.Application.Features.Customers;
using BlazorProject.Application.Features.Invoices;
using BlazorProject.Application.Features.Items;
using BlazorProject.Application.Features.Taxes;
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
		public Type Dto { get; set; }
        
    }
	public static class ApplicationRegistration
	{
		public static IServiceCollection AddApplicationServies(this IServiceCollection services)
		{
			services.AddMediatR(config =>
			
				config.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
			);
			services.AddRequestHandlers(new List<EntityTypes> {
				new EntityTypes { Entity=typeof(Item),Dto=typeof(ItemDto)}
				,new EntityTypes { Entity = typeof(Tax), Dto = typeof(TaxDto) }
				,new EntityTypes {Entity= typeof(Customer),Dto=typeof(CustomerDto)}
				,new EntityTypes {Entity= typeof(Invoice),Dto=typeof(InvoiceDto)}
			});
			services.AddScoped<IHandlerCustomLogic<Invoice>,InvoiceHandlerLogic>();
			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
			return services;

		}
		private static void AddRequestHandlers(this IServiceCollection services,List<EntityTypes> types)
		{
			var requestInterface = typeof(IRequest<>);
			var assemblytypes = Assembly.GetExecutingAssembly().GetTypes();
			var requestTypes= assemblytypes.Where(type=> type.GetInterfaces().Any(i=> i.IsGenericType&& i.GetGenericTypeDefinition()== requestInterface)).ToList();
			foreach (var type in types)
			{
				foreach(var requestType in requestTypes)
				{
					Type request= requestType.MakeGenericType(type.Entity, type.Dto);
					Type response;
					Type handler;
					Type requestHandlerImplType;

					if (requestType.GetGenericTypeDefinition() == typeof(GetAllQuery<,>))
					{
						response= typeof(BaseResponse<>).MakeGenericType(typeof(List<>).MakeGenericType(type.Dto));
						handler = typeof(GetAllQueryHandler<,>);
					}
					else if(requestType.GetGenericTypeDefinition() == typeof(GetOneQuery<,>))
					{
						response = typeof(BaseResponse<>).MakeGenericType(type.Dto);
						handler = typeof(GetOneQueryHandler<,>);
					}
					else if(requestType.GetGenericTypeDefinition()== typeof(CreateCommand<,>))
					{
						response = typeof(BaseResponse<int>);
						handler = typeof(CreateCommandHandler<,>);
					}
					else if (requestType.GetGenericTypeDefinition() == typeof(UpdateCommand<,>))
					{
						response = typeof(BaseResponse);
						handler = typeof(UpdateCommandHandler<,>);
					}
					else
					{
						response = typeof(BaseResponse);
						handler = typeof(DeleteCommandHandler<,>);
					}
					var requestHandlerType = typeof(IRequestHandler<,>).MakeGenericType(request, response);
					
					requestHandlerImplType = handler.MakeGenericType(type.Entity,type.Dto);
					
					services.AddTransient(requestHandlerType, requestHandlerImplType);
				}
			}
		}
	}
}
