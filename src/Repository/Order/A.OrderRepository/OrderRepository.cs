using A.Domain.Models;
using A.OrderRepository.Context;
using System.Collections.Generic;
using System.Linq;

namespace A.OrderRepository
{
  public class OrderRepository : IOrderRepository
  {
    private OrderDBContext _context;

    public OrderRepository(OrderDBContext context)
    {
      _context = context;
    }

        public List<Order> GetAllOrders()
        {
            return _context.Orders.Local.ToList();
        }

        public Order GetOrderById(string orderId)
        {
            return _context.Orders.Where(ord => ord.OrderId == orderId).FirstOrDefault();
        }
    }
}