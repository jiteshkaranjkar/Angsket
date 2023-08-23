using A.OrderRepository.Repository;
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

        public List<Order> GetAllOrders() => orderRepository.GetAllOrders();

        public Order GetOrderById(string id) => orderRepository.GetOrderById(id);
    }
}