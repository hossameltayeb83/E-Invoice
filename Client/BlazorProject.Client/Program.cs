using BlazorProject.Client.Services;
using BlazorProject.Shared;
using BlazorProject.Shared.Dtos;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BlazorProject.Client
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("#app");
			builder.RootComponents.Add<HeadOutlet>("head::after");
			builder.Services.AddSharedServices();
			builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["API"]!) });
            builder.Services.AddBlazorBootstrap();
			//builder.Services.AddScoped(typeof(IService<>), typeof(BaseService<>));
			builder.Services.AddScoped<IService<ItemDto>, ItemsService>();
			builder.Services.AddScoped<IService<TaxDto>, TaxesService>();
			builder.Services.AddScoped<IService<CustomerDto>, CustomersService>();
			builder.Services.AddScoped<IService<InvoiceDto>, InvoicesService>();
			//builder.Services.AddScoped<ICustomerService, CustomersService>();
			await builder.Build().RunAsync();
		}
	}
}
