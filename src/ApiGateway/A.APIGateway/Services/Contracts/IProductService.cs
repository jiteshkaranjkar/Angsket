using A.APIGateway.Models;
using System.Collections.Generic;

namespace A.APIGateway.Services.Contracts
{
    public interface IProductService
    {
        List<ProductEntity> GetAllProducts();

        ProductEntity GetProductById(int id);
    }
}
