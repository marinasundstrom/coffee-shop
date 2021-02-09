using System;
using App1.Application.Products;
using Microsoft.Extensions.DependencyInjection;

namespace App1.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ProductListingService>();
            services.AddScoped<DiscountService>();
            services.AddScoped<PriceService>();

            return services;
        }
    }
}
