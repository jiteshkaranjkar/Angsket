using A.OrderRepository;
using A.Domain.Models;
using System.Collections.Generic;

namespace A.OrderService.API
{
    public class OrderService : IOrderService
    {
        private IOrderRepository orderRepository;

        public OrderService(IOrderRepository orderRepo)
        {
            orderRepository = orderRepo;
        }

        public List<Order> GetAllOrders()
        {
            return orderRepository.GetAllOrders();
        }

        public Order GetOrderById(string id)
        {
            return orderRepository.GetOrderById(id);
        }
    }
}