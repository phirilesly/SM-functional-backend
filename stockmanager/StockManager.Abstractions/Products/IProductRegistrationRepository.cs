using Property365.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.Abstractions.Products
{
    public interface IProductRegistrationRepository : IEntityStateRepository<ProductRegistrationState, Guid>
    {
    }
}
