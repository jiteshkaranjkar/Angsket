using A.APIGateway.Models;
using System.Collections.Generic;

namespace A.APIGateway.Contracts
{
    public interface IProductService
    {
        List<Product> GetAllProducts();

        Product GetProductById(int id);
    }
}
