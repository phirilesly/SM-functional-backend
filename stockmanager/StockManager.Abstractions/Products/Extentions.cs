using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.Abstractions.Products
{
    public static class ProductExtentions
    {
        public static ProductRegistered ToRegisteredEvent(this ProductRegistrationState product)
        {
            return new ProductRegistered(product.Id, product.Name, product.Description, product.Category, product.Price, "testuser", Guid.Empty, DateTime.Now);
        }

        public static ProductUpdated ToUpdatedEvent(this ProductRegistrationState product)
        {
            return new ProductRegistered(product.Id, product.Name, product.Description, product.Category, product.Price, "testuser", Guid.Empty, DateTime.Now);
        }
    }
}
