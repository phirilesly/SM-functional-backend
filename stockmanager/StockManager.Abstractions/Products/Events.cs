using Property365.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.Abstractions.Products
{
    public record ProductRegistered(Guid Id, string Name, string Description, string Category, float Price, string UserId, Guid SubscriptionId, DateTime TimeStamp) : Event(Id,TimeStamp);

    public record ProductDeleted(Guid Id,  string UserId, Guid SubscriptionId, DateTime TimeStamp)
   : Event(Id, TimeStamp);

    public record ProductNameChanged(Guid Id, string Name, string UserId, Guid SubscriptionId, DateTime TimeStamp) : Event(Id, TimeStamp);

    public record ProductUpdated(Guid Id, string Name, string Description, string Category, float Price, string UserId, Guid SubscriptionId, DateTime TimeStamp) : Event(Id, TimeStamp);
}
