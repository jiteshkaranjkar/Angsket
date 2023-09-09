using A.BasketRepository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace A.BasketRepository
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddBasketInfrastructure(this IServiceCollection services)
    {
      services.AddDbContext<BasketDBContext>(options => options.UseInMemoryDatabase("Angsket"), ServiceLifetime.Scoped, ServiceLifetime.Scoped);
      services.AddScoped<IBasketRepository, BasketRepository>();

      return services;
    }
  }
}