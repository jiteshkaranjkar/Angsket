using A.APIGateway.Contracts;
using A.APIGateway.Models;
using A.APIGateway.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Basket>> GetBasketAsync([FromBody] UpdateBasketRequest basketRequest)
        {
            return null;
        }

        [HttpPost]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Basket>> UpdateBasketAsync([FromBody] UpdateBasketRequest basketRequest)
        {
            if (basketRequest.Items == null || !basketRequest.Items.Any())
            {
                return BadRequest("Need to pass at least one basket line");
            }

            // Retrieve the current basket
            var basket = new Basket(basketRequest.BuyerId);

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
                    basket.Items.Add(new Product()
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