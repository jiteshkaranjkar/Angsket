using A.APIGateway.Models;
using A.APIGateway.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace A.APIGateway.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService basketService;
        private readonly IProductService productServie;
        private readonly ILogger<BasketController> _logger;

        public BasketController(IBasketService basketService, ILogger<BasketController> logger)
        {
            this.basketService = basketService;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BasketEntity>> GetBasketAsync([FromBody] string buyerId)
        {
            var currentBasket = (await basketService.GetBasketByIdAsync(buyerId));
            return currentBasket;
        }

        [HttpPost]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BasketEntity>> UpdateBasketAsync([FromBody] UpdateBasketRequest basketRequest)
        {
            if (basketRequest.Items == null || !basketRequest.Items.Any())
            {
                return BadRequest("Need to pass at least one basket line");
            }

            // Retrieve the current basket
            var basket = new BasketEntity(basketRequest.BuyerId);

            // group by product id to avoid duplicates
            var itemsCalculated = basketRequest
                    .Items
                    .GroupBy(x => x.ProductId, x => x, (k, i) => new { productId = k, items = i })
                    .Select(groupedItem =>
                    {
                        var item = groupedItem.items.First();
                        item.Quantity = groupedItem.items.Sum(i => i.Quantity);
                        return item;
                    });

            foreach (var bitem in itemsCalculated)
            {
                var itemInBasket = basket.Items.FirstOrDefault(x => x.Id == bitem.ProductId);
                if (itemInBasket == null)
                {
                    basket.Items.Add(new ProductEntity()
                    {
                        Id = bitem.ProductId,
                        //Name = bitem.,
                        //ImageURL = catalogItem.PictureUri,
                        //UnitPrice = catalogItem.Price,
                        //Quantity = bitem.Quantity
                    });
                }
                else
                {
                    itemInBasket.BasketQuantity = bitem.Quantity;
                }
            }

            await basketService.UpdateBasketAsync(basket);

            return basket;
        }
    }
}