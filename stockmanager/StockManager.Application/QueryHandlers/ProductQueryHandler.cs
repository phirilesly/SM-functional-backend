using Property365.Common;
using StockManager.Abstractions.Products;
using StockManager.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.Application.QueryHandlers
{
    public class ProductQueryHandler : IProductQueryHandler
    {
        IProductRegistrationRepository _productRegistrationRepository;
        public ProductQueryHandler(IProductRegistrationRepository productRegistrationRepository)
        {

            _productRegistrationRepository = productRegistrationRepository;
        }
        public Task<IEnumerable<ProductRegistrationState>> FindProducts(List<SearchParameter> searchParameters)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductRegistrationState> GetProduct(Guid Id)
        {
            return await _productRegistrationRepository.GetEntityStateAsync(Id);
        }
    }
}
