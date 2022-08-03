using StockManager.Abstractions.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.GraphQL.Types
{
    public class ProductType : ObjectType<ProductRegistrationState>
    {
        protected override void Configure(IObjectTypeDescriptor<ProductRegistrationState> descriptor)
        {
            descriptor
              .Field(f => f.Description)
              .Type<StringType>();
            descriptor
               .Field(f => f.Name)
               .Type<StringType>();
            descriptor
               .Field(f => f.Category)
               .Type<StringType>();
            descriptor
               .Field(f => f.Price)
               .Type<FloatType>();
            descriptor
               .Field(f => f.Id)
               .Type<UuidType>();
        }
        }
}
