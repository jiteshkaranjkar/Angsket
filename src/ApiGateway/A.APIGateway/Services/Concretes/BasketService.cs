using A.APIGateway.Models;
using A.APIGateway.Services.Contracts;

namespace A.APIGateway.Services.Concretes
{
    //private readonly Basket.BasketClient _basketClient;
    public class BasketService : IBasketService
    {

        public Task<Basket> GetBasketByIdAsync(string buyerid)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBasketAsync(Basket basket)
        {
            throw new NotImplementedException();
        }
    }
}
