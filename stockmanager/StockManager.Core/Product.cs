using Property365.Common;
using Property365.Functional;
using StockManager.Abstractions.Products;
using static Property365.Functional.F;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StockManager.Core
{
    public static class Product
    {
        static Regex nameRegex = new Regex("^[a-zA-Z0-9_]*$");
   

        public static Either<Error, RegisterProduct> ValidateProductName(RegisterProduct cmd)
          => nameRegex.IsMatch(cmd.Name) ? cmd : Errors.InvalidSchemeName;

        public static Either<Error, ProductRegistered> RegisterProduct(RegisterProduct cmd)
    => ValidateProductName(cmd)
       .Bind(ConfirmProductRegistration);
        public static Either<Error, ProductRegistered> ConfirmProductRegistration(RegisterProduct cmd)
          => new ProductRegistered(Guid.NewGuid(), cmd.Name, cmd.Description, cmd.Category, cmd.Price, cmd.UserId, cmd.SubscriptionId,DateTime.Now);
        public static ProductRegistrationState Apply(this ProductRegistrationState state, Event @event)
          => @event switch
          {

              ProductRegistered e
              => state with { Id = e.EntityId, Description= e.Description, Category = e.Category, Price = e.Price, Name = e.Name },
              ProductNameChanged e
              => state with { Name = e.Name },

              _ => throw new InvalidOperationException()
          };

        public static ProductRegistrationState Create(ProductRegistered evt)
        => new ProductRegistrationState(evt.Id, evt.Name, evt.Description, evt.Category, evt.Price);
        public static Option<ProductRegistrationState> From(IEnumerable<Event> history)
          => history.Match
            (
                 Empty: () => None,
                 Otherwise: (created, otherEvents) => Some
                    (
                        otherEvents.Aggregate
                        (
                        seed: Product.Create((ProductRegistered)created),
                        func: (state, evt) => state.Apply(evt)
                        )
                    )
            );
    }
}
