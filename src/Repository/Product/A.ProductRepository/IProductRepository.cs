using A.Domain.Models;
using System.Collections.Generic;

namespace A.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> UpdateProductAsync(Product product);
    }
}
