using A.BasketRepository;
using A.Domain.Models;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;

namespace A.BasketService.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly ILogger<BasketController> _logger;
        IBasketRepository basketRepository;

        public BasketController(IBasketRepository repository, ILogger<BasketController> logger)
        {
            basketRepository = repository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<Basket>> GetBasketById(string buyerid)
        {
            var basket = basketRepository.GetBasketByIdAsync(buyerid);
            if (basket == null)
            {
                return new Basket(buyerid);
            }
            return Ok(basket);
        }

        [HttpPost]
        public async Task<ActionResult<Basket>> UpdateBasket(Basket basket)
        {
            return Ok(await basketRepository.UpdateBasketAsync(basket));
        }
    }
}