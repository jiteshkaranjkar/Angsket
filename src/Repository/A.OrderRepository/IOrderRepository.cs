using A.Domain.Models;
using System.Collections.Generic;


namespace A.OrderRepository.Repository
{
    public interface IOrderRepository
    {
        List<Order> GetAllOrders();

        Order GetOrderById(string id);
    }
}
