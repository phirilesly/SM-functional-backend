using Microsoft.AspNetCore.Mvc;
using StockManager.Abstractions.Products;
using StockManager.Application;

namespace StockManager.API.EndPoints
{
    internal abstract class Products
    {
        internal static async Task<IResult> RegisterProduct([FromBody] NewProduct newProduct)
      => ProductManager
        .RegisterProduct(new RegisterProduct(newProduct.Name, newProduct.Description, newProduct.Category, newProduct.Price, "", Guid.Empty))
        .Match<IResult>(
         Left: errs => Results.BadRequest(new { Errors = errs }),
         Right: result => Results.Ok(result));
    }
}
