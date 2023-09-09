using A.Domain.Models;
using A.ProductRepository.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace A.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private ProductDBContext productContext;

        public ProductRepository(ProductDBContext context)
        {
            productContext = context;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return productContext.Products.Local.ToList();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await productContext.Products.Where(b => b.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            return await productContext.Products.Where(prod => prod.Id == product.Id).FirstOrDefaultAsync();
        }
    }
}