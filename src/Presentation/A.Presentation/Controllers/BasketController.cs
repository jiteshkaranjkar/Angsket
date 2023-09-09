//using A.BasketService.API.Grpc;
//using A.Domain.Models;
//using Microsoft.AspNetCore.Mvc;

//namespace A.Presentation.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class BasketController : ControllerBase
//    {
//        private readonly IBasketService _basketService;
//        private readonly ILogger<BasketController> _logger;

//        public BasketController(IBasketService basketService, ILogger<BasketController> logger)
//        {
//            _basketService = basketService;
//            _logger = logger;
//        }

//        [HttpGet]
//        public ActionResult<Basket> GetBasket()
//        {
//            return _basketService.GetBasket();
//        }

//        [HttpPost]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        public ActionResult<Basket> UpdateBasket([FromBody] Basket basket)
//        {
//            if (basket.Items == null || !basket.Items.Any())
//            {
//                return BadRequest("Need to pass at least one basket line");
//            }

//            return Ok(_basketService.UpdateBasket(basket));
//        }
//    }
//}