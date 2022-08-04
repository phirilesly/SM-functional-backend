using Microsoft.AspNetCore.Http.Json;
using StockManager.API.Configuration;
using System.Text.Json.Serialization;
using MvcJsonOptions = Microsoft.AspNetCore.Mvc.JsonOptions;

namespace StockManager.API.Host.Configuration
{
    public static class ServicesConfiguration
    {

        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddStockManager(configuration);

            services.Configure<JsonOptions>(options => {
                options.SerializerOptions.AllowTrailingCommas = true;
                options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
            services.Configure<MvcJsonOptions>(options => {
                options.JsonSerializerOptions.AllowTrailingCommas = true;
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            return services;
        }
    }
}
