using A.Domain.Models;
using System.Collections.Generic;


namespace A.OrderRepository
{
    public interface IOrderRepository
    {
        List<Order> GetAllOrders();

        Order GetOrderById(string id);
    }
}
