using A.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace A.ProductRepository.Context
{
    public class ProductDBContext : DbContext
    {
        public ProductDBContext(DbContextOptions<ProductDBContext> options) : base(options)
        {
            ProductDBContextSeeder seedProducts = new();
            seedProducts.Seed(this);
        }
        public DbSet<Product> Products { get; set; }
    }
}
