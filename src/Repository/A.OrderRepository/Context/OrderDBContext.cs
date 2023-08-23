using Microsoft.EntityFrameworkCore;
using A.Domain.Models;

namespace A.OrderRepository.Context
{
    public class OrderDBContext : DbContext
    {
        public OrderDBContext(DbContextOptions<OrderDBContext> options) : base(options)
        {
            OrderDBContextSeeder seedOrders = new();
            seedOrders.Seed(this);
        }
        public DbSet<Order> Orders { get; set; }

    }
}
