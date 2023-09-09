using Microsoft.EntityFrameworkCore;
using A.Domain.Models;

namespace A.BasketRepository.Context
{
    public class BasketDBContext : DbContext
    {
        public BasketDBContext(DbContextOptions<BasketDBContext> options) : base(options)
        {
            BasketDBContextSeeder seedBaskets = new();
            seedBaskets.Seed(this);
        }
        public DbSet<Basket> Basket { get; set; }
    }
}
