using A.Domain.Models;
using System.Collections.Generic;

namespace A.ProductService.API
{
    public interface IProductService
    {
        List<Product> GetAllProducts();

        Product GetProductById(int id);
    }
}
