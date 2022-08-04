using Property365.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.Abstractions.Products
{
 public record RegisterProduct(string Name,string Description,string Category,float Price, string UserId, Guid SubscriptionId):AuthenticatedCommand(UserId, SubscriptionId);
    public record DeleteProduct(Guid Id, string UserId, Guid SubscriptionId): AuthenticatedCommand(UserId, SubscriptionId);
    public record UpdatedProduct(Guid Id,string Name, string Description, string Category, float Price, string UserId, Guid SubscriptionId): AuthenticatedCommand(UserId, SubscriptionId);

    public record ChangeProductName(Guid Id, string Name, string UserId, Guid SubscriptionId) : AuthenticatedCommand(UserId, SubscriptionId);
}
