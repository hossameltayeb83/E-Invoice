using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorProject.Shared.Dtos;
using BlazorProject.Shared.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorProject.Shared
{
    public static class SharedRegistration
    {
        public static IServiceCollection AddSharedServices(this IServiceCollection services)
        {
            services.AddScoped<AbstractValidator<InvoiceDto>,InvoiceValidator>();
            services.AddScoped<AbstractValidator<ItemDto>,ItemValidator>();
            services.AddScoped<AbstractValidator<TaxDto>,TaxValidator>();
            services.AddScoped<AbstractValidator<CustomerDto>,CustomerValidator>();
            return services;
        }
    }
}
