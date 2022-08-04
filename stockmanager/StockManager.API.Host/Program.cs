using Autofac;
using Autofac.Extensions.DependencyInjection;
using Property365.Common.Messaging;
using StockManager.Abstractions.Products;
using StockManager.API.Host.Configuration;
using StockManager.API.Services;
using StockManager.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.ConfigureServices(builder.Configuration);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
// Register services directly with Autofac here. Don't
// call builder.Populate(), that happens in AutofacServiceProviderFactory.
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new EventsModule()));

var app = builder.Build();
app.ConfigureApp(app.Environment);

ProductManager.ConfigureProductEventStore(app.Services.GetRequiredService<IProductEventStore>(),
    app.Services.GetRequiredService<IEventDispatcher>());


app.Run();
