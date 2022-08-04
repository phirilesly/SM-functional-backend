using Microsoft.OpenApi.Models;

namespace StockManager.API.Configuration.Swashbuckle
{
    public static class SwaggerBootstrapper
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {

            services.AddEndpointsApiExplorer()
                .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Stock Manager API", Version = "v1" });
                });
            return services;
        }
    }
}
