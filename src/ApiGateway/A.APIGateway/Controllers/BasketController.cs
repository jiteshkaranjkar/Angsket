using A.APIGateway.Models;
using Microsoft.AspNetCore.Mvc;

namespace A.APIGateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly ILogger<BasketController> _logger;

        public BasketController(ILogger<BasketController> logger)
        {
            _logger = logger;
        }
    }
}