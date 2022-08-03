using Property365.Common;
using StockManager.Abstractions.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.Abstractions.Services
{
    public interface IProductQueryHandler
    {
        Task<ProductRegistrationState> GetProduct(Guid Id);
        Task<IEnumerable<ProductRegistrationState>> FindProducts(List<SearchParameter> searchParameters);
    }
}
