using A.Domain.Models;
using A.ProductService.API;
using Microsoft.AspNetCore.Mvc;

namespace A.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductService productService, ILogger<ProductsController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpGet]
        public List<Product> GetAllProducts()
        {
            return _productService.GetAllProducts();
        }
    }
}