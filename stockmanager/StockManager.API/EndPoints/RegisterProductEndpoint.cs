using StockManager.Abstractions.Products;

namespace StockManager.API.EndPoints
{
    internal static class RegisterProductEndpoint
    {
        internal static IEndpointRouteBuilder UseRegisterProductEndpoint(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapPost("products/register", Products.RegisterProduct)
            .Produces(StatusCodes.Status200OK, typeof(ProductRegistrationState));

            endpoints.MapPut("products/update", Products.UpdateProduct)
                .Produces(StatusCodes.Status200OK, typeof(ProductRegistrationState));

            // .RequireAuthorization();
            return endpoints;
        }


    }
}
