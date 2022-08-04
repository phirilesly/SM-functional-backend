using Property365.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.Abstractions.Products
{
    public record ProductRegistrationState(Guid Id, string Name, string Description, string Category, float Price):IEntity
    {
        public static ProductRegistrationState Empty
            => new(default, default, default, default, default);

    }

    public record ProductUpdatingState(Guid Id, string Name, string Description, string Category, float Price) : IEntity
    {
        public static ProductUpdatingState Empty
            => new(default, default, default, default, default);

    }
}
