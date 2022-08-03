using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.Abstractions.Products
{
  public record NewProduct
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public string Category { get; set; }

        public float Price { get; set; }
    }
}
