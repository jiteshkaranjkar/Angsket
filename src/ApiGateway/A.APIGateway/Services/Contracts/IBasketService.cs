using A.APIGateway.Models;

namespace A.APIGateway.Services.Contracts
{
    public interface IBasketService
    {
        Task<BasketEntity> GetBasketByIdAsync(string buyerid);
        Task UpdateBasketAsync(BasketEntity basket);
    }
}
