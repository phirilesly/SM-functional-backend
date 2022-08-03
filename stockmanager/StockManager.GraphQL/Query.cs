using StockManager.GraphQL.Resolvers;
using StockManager.GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.GraphQL
{
    public class Query
    {
    }

    public class QueryType : ObjectType<Query>
    {

        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor
                .Field("products")
                .Description("Registered products")
                .Type<ListType<ProductType>>()
                .Argument("productId", a => a.Type<UuidType>())
                .ResolveWith<ProductResolvers>(resolver => resolver.GetProducts(default, default));
        }

    }
}
