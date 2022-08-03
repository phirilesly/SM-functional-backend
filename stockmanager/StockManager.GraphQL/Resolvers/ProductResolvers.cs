using Property365.Common;
using StockManager.Abstractions.Products;
using StockManager.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.GraphQL.Resolvers
{
    public class ProductResolvers
    {
        public async Task<IEnumerable<ProductRegistrationState>> GetProducts([Service] IProductQueryHandler queryHandler, Guid? schemeId)
        {
            var searchParameters = new List<SearchParameter>();
            if (schemeId.HasValue)
            {
                return new List<ProductRegistrationState> { await queryHandler.GetProduct(schemeId.Value) };
            }
            return queryHandler.FindProducts(searchParameters).Result.ToList();
        }
    }
}
