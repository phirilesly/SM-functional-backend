using StockManager.API.Configuration;
using StockManager.GraphQL;

namespace StockManager.API.Host.Configuration
{
    public static class ApplicationConfiguration
    {
        public static IApplicationBuilder ConfigureApp(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage()
                    .UseSwagger()
                    .UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Stock Manager API"));

            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.UseStockManagerEndpoints();
                endpoints.UseStockManagerGraphQL();
            });
            return app;
        }
    }
}
