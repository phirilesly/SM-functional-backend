using Property365.Common.Messaging;
using StockManager.Abstractions.Products;
using StockManager.API.EndPoints;
using StockManager.Infrastructure;

namespace StockManager.API
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddStockManagerServices(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<MongoContext>();
            services.AddSingleton<IProductEventStore, ProductEventStore>();
            services.AddSingleton<IProductRegistrationRepository, ProductRegistrationRepository>();
            services.AddSingleton<IEventDispatcher, EventDispatcher>();
            return services;
        }

        public static IEndpointRouteBuilder StockManagerEndpoints(this IEndpointRouteBuilder endpoints)
            => endpoints.UseRegisterProductEndpoint();
    }
}
