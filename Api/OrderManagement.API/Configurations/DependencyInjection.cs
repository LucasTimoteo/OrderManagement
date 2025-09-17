using OrderManagement.Application.Interfaces.Repositories;
using OrderManagement.Application.Interfaces.Services;
using OrderManagement.Application.Services;
using OrderManagement.Infrastructure.Repositories;

namespace OrderManagement.API.Configurations;

public static class DependencyInjection
{
    public static IServiceCollection ConfigDependency(this IServiceCollection services)
    {
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IStockRepository, StockRepository>();
        services.AddScoped<IPromotionRepository, PromotionRepository>();
        services.AddScoped<IStockProductRepository, StockProductRepository>();
        services.AddScoped<IProductPromotionRepository, ProductPromotionRepository>();

        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IPriceService, PriceService>();

        return services;
    }
}
