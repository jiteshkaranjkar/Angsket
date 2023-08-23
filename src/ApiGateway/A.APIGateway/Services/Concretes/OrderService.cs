using A.APIGateway.Models;
using A.APIGateway.Services.Contracts;

namespace A.APIGateway.Services.Concretes
{
    public class OrderService : IOrderService
    {
        public Task<Order> GetOrderAsync(Basket basket)
        {
            throw new NotImplementedException();
        }
    }
}