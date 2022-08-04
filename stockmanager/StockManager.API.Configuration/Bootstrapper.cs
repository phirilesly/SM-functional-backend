using StockManager.API.Configuration.Swashbuckle;
using StockManager.GraphQL;

namespace StockManager.API.Configuration
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddStockManager(this IServiceCollection services, IConfiguration configuration)
            => services.AddStockManagerServices()
                       .AddProductsGraphQL()
                       .AddSwagger();

        public static IEndpointRouteBuilder UseStockManagerEndpoints(this IEndpointRouteBuilder endpoints)
            => endpoints.StockManagerEndpoints();
    }
}
