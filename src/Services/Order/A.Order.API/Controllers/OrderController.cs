using A.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace A.OrderService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService, ILogger<OrderController> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }

        [HttpGet]
        public List<Order> GetAllOrders()
        { 
         return _orderService.GetAllOrders();
        }
    }
}