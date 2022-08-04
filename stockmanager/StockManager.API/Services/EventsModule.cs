using Autofac;
using Property365.Common.Messaging;
using System.Reflection;

namespace StockManager.API.Services
{
  
        public class EventsModule : Autofac.Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                builder.RegisterType<EventDispatcher>()
                    .As<IEventDispatcher>()
                    .InstancePerLifetimeScope();
                var assembly = Assembly.Load(new AssemblyName("StockManager.Application"));
                builder.RegisterAssemblyTypes(assembly).AsClosedTypesOf(typeof(IEventHandler<>));
            }
        }

        public static class Container
        {
            public static IContainer Resolve()
            {
                var builder = new ContainerBuilder();
                builder.RegisterModule<EventsModule>();

                return builder.Build();
            }
        }
    }

