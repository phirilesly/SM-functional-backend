using Microsoft.Extensions.Logging;
using Property365.Common.Messaging;
using StockManager.Abstractions.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.Application.EventHandlers.Products
{
    public class ProductRegisteredEventHandler : IEventHandler<ProductRegistered>
    {
        private ILogger<ProductRegisteredEventHandler> _logger;
        private IProductEventStore _productEventStore;
        private IProductRegistrationRepository _productRegistrationRepository;

        public string HandlerName => GetType().Name.ToLower();

        public ProductRegisteredEventHandler(IProductEventStore productEventStore,
             IProductRegistrationRepository productRegistrationRepository,
             ILogger<ProductRegisteredEventHandler> logger)
        {
            _logger = logger;
            _productEventStore = productEventStore;
            _productRegistrationRepository = productRegistrationRepository;

        }
        public Task HandleAsync(ProductRegistered @event)
        {
            return Task.Run(() => _productRegistrationRepository.SaveEntityStateAsync(new ProductRegistrationState(@event.Id, @event.Name, @event.Description, @event.Category, @event.Price)));
            ;
        }
    }
}
