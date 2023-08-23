using A.Domain.Models;
using System.Collections.Generic;

namespace A.OrderService.API
{
  public interface IOrderService
  {
    List<Order> GetAllOrders();

    Order GetOrderById(string id);
  }
}
