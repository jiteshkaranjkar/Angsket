using A.APIGateway.Models;

namespace A.APIGateway.Services.Contracts
{
    public interface IBasketService
    {
        Task<Basket> GetBasketByIdAsync(string buyerid);
        Task UpdateBasketAsync(Basket basket);
    }
}
