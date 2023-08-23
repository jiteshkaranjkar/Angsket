using A.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace A.BasketService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly ILogger<BasketController> _logger;
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService, ILogger<BasketController> logger)
        {
            _basketService = basketService;
            _logger = logger;
        }

        [HttpGet]
        public List<Basket> GetAllBasket()
        {
            return _basketService.GetAllBasket();
        }
    }
}