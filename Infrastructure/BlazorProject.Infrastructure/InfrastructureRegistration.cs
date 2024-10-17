using BlazorProject.Application.Contracts;
using BlazorProject.Application.Contracts.Infrastructre;
using BlazorProject.Infrastructure.Data;
using BlazorProject.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Infrastructure
{
	public static class InfrastructureRegistration
	{
		public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ProjectContext>(options =>
			{
				options.UseSqlServer(configuration.GetConnectionString("Connection"));
			});
			services.AddScoped(typeof(IRepository<>),typeof(BaseRepository<>));
			services.AddScoped<IInvoiceRepository,InvoiceRepository>();
			services.AddScoped<ICustomerRepository,CustomerRepository>();
			services.AddScoped<IItemRepository,ItemRepository>();
			services.AddScoped<ITaxRepository,TaxRepository>();
			return services;
		}
	}
}
