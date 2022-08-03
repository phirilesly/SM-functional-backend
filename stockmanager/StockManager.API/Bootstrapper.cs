namespace StockManager.API
{
    public class Bootstrapper
    {
        public static IServiceCollection AddSectionalTitleServices(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<MongoContext>();
            services.AddSingleton<ISchemeEventStore, SchemeEventStore>();
            services.AddSingleton<ISchemeRegistrationRepository, SchemeRegistrationRepository>();
            services.AddSingleton<IEventDispatcher, EventDispatcher>();
            return services;
        }

        public static IEndpointRouteBuilder SectionalSchemesEndpoints(this IEndpointRouteBuilder endpoints)
            => endpoints.UseRegisterSchemeEndpoint();
    }
}
