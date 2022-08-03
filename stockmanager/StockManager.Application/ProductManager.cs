using Property365.Common;
using Property365.Common.Messaging;
using Property365.Functional;
using StockManager.Abstractions.Products;
using StockManager.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.Application
{
    public static class ProductManager
    {
        private static IProductEventStore _productEventStore;
        private static IEventDispatcher _dispatcher;
        public static void ConfigureSchemeEventStore(IProductEventStore productEventStore, IEventDispatcher dispatcher)
        {
            _productEventStore = productEventStore;
            _dispatcher = dispatcher;
        }
        public static Either<Error, ProductRegistrationState> RegisterProduct(RegisterProduct cmd)
            => Product
            .RegisterProduct(cmd)
            .Bind(SaveProductRegistrationState);
        public static Either<Error, ProductRegistrationState> SaveProductRegistrationState(ProductRegistered @event)
        {
            var state = new ProductRegistrationState(@event.Id, @event.Name, @event.Description, @event.Category, @event.Price);

            var record = new EventRecord(Guid.NewGuid(), @event.Id, DateTime.Now, "ProductRegistered", @event);
            _productEventStore.Persist(record).Wait(); ;
            _dispatcher.DispatchAsync(new List<ProductRegistered> { @event }).Wait();

            var history = _productEventStore.GetEvents(@event.Id).Result;

            var events = history
                 .Bind(h => h.AsEnumerable().Select(r => r.Data));

            var newState = Product.From(events);


            return state;
        }

    }
}
