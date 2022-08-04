using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using StockManager.Abstractions.Products;
using StockManager.Abstractions.Services;
using StockManager.Application.QueryHandlers;
using StockManager.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.GraphQL
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddProductsGraphQL(this IServiceCollection services)
        {
            services.AddSingleton<IProductEventStore, ProductEventStore>();
            services.AddSingleton<IProductRegistrationRepository, ProductRegistrationRepository>();
            services.AddSingleton<IProductQueryHandler, ProductQueryHandler>();
            services.AddGraphQLServer()
                    .AddQueryType<QueryType>()
                    .ModifyOptions(options =>
                    {
                        options.DefaultBindingBehavior = BindingBehavior.Explicit;
                    }
                    );
            return services;
        }

        public static IEndpointRouteBuilder UseStockManagerGraphQL(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGraphQL();
            return endpoints;
        }
    }
}
