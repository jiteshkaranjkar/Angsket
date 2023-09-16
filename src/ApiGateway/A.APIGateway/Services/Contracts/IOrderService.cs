using A.APIGateway.Models;

namespace A.APIGateway.Services.Contracts
{
    public interface IOrderService
    {
        Task<Order> GetOrderAsync(BasketEntity basket);
    }
}
