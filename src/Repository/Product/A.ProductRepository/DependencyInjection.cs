using A.ProductRepository;
using A.ProductRepository.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace A.ProductRepository
{
    public static class DependencyInjection
  {
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
      services.AddDbContext<ProductDBContext>(options => options.UseInMemoryDatabase("AngsketProduct"), ServiceLifetime.Scoped, ServiceLifetime.Scoped);
      services.AddScoped<IProductRepository, ProductRepository>();

      return services;
    }
  }
}