
using BlazorProject.Application;
using BlazorProject.Infrastructure;
using BlazorProject.Server.Middlewares;
using BlazorProject.Shared;

namespace BlazorProject.Server
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			builder.Services.AddApplicationServies();
			builder.Services.AddInfrastructureServices(builder.Configuration);
			builder.Services.AddSharedServices();

			builder.Services.AddCors(
				options=> options.AddPolicy("BlazorApp",policy=>policy.WithOrigins(builder.Configuration["BlazorApp"]!).AllowAnyMethod().AllowAnyHeader().AllowCredentials().SetIsOriginAllowed(policy=>true)));

			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}
			app.UseCustomExceptionHandler();

			app.UseHttpsRedirection();
            app.UseCors("BlazorApp");
            app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
