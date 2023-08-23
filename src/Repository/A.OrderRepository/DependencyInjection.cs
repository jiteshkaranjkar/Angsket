using A.OrderRepository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace A.OrderRepository.Repository
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
      services.AddDbContext<OrderDBContext>(options => options.UseInMemoryDatabase("Angsket"), ServiceLifetime.Scoped, ServiceLifetime.Scoped);
      services.AddScoped<IOrderRepository, OrderRepository>();

      return services;
    }
  }
}