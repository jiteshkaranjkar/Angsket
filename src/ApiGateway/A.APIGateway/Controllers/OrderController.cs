using A.APIGateway.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace A.APIGateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }
    }
}