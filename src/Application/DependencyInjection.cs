using Microsoft.Extensions.DependencyInjection;
using OrderManagementSystem.Application.Services;
using OrderManagementSystem.Application.Services.Interfaces;

namespace OrderManagementSystem.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IDiscountService, DiscountService>();
            services.AddScoped<IOrderService, OrderService>();

            return services;
        }
    }
}
