using A.ProductRepository;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;

namespace GrpcProduct
{
    public class ProductService : Product.ProductBase
    {
        private IProductRepository ProductRepository;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IProductRepository repository, ILogger<ProductService> logger)
        {
            ProductRepository = repository;
        }

        [AllowAnonymous]
        public override async Task<ProductsResponse> GetAllProductAsync(ProductsRequest request, ServerCallContext context)
        {
            _logger.LogInformation($"Begin grpc call from method {context.Method} for Product id {request.Ids}");
            if (string.IsNullOrEmpty(request.Ids))
            {
                context.Status = new Status(StatusCode.FailedPrecondition, $"Id must not be null or empty (received {request.Ids})");
                return null;
            }
            var products = await ProductRepository.GetAllProductsAsync();
            ProductsResponse responses = new ProductsResponse();
            if (products != null)
            {
                context.Status = new Status(StatusCode.OK, $"Products exists");
                foreach (var prod in products)
                {
                    responses.Data.Add(MapToProductResponse(prod));
                }
            }
            else
            {
                context.Status = new Status(StatusCode.NotFound, $"Product with Id {request.Ids} do not exist");
            }
            return responses;
        }


        [AllowAnonymous]
        public override async Task<ProductResponse> GetProductByIdAsync(ProductRequest request, ServerCallContext context)
        {
            _logger.LogInformation($"Begin grpc call from method {context.Method} for Product id {request.Id}");
            if (request.Id <= 0)
            {
                context.Status = new Status(StatusCode.FailedPrecondition, $"Id must be > 0 (received {request.Id})");
                return null;
            }
            var product = await ProductRepository.GetProductByIdAsync(request.Id);
            if (product != null)
            {
                context.Status = new Status(StatusCode.OK, $"Product with Id {request.Id} exists");
                return MapToProductResponse(product);
            }
            else
            {
                context.Status = new Status(StatusCode.NotFound, $"Product with Id {request.Id} do not exist");
            }
            return new ProductResponse();
        }

        public override async Task<ProductResponse> UpdateProductAsync(ProductUpdateRequest request, ServerCallContext context)
        {
            _logger.LogInformation($"Begin grpc call ProductService.UpdateProductAsync for buyer id {request.Id}");

            var requestProduct = MapRequestToProduct(request);

            var Product = await ProductRepository.UpdateProductAsync(requestProduct);
            if (Product != null)
            {
                context.Status = new Status(StatusCode.OK, $"Product with Id {request.Id} exists");
                return MapToProductResponse(Product);
            }
            context.Status = new Status(StatusCode.NotFound, $"Product with buyer id {request.Id} do not exist");

            return null;
        }

        private ProductResponse MapToProductResponse(A.Domain.Models.Product Product)
        {
            var response = new ProductResponse
            {
                Id = Product.Id,
                Name = Product.Name,
                Brand = Product.Brand,
                Type = Product.Type,
                Description = Product.Description,
                UnitPrice = Product.UnitPrice,
                PromtionalUnitPrice = Product.PromtionalUnitPrice,
                ImageURL = Product.ImageURL,
                Promotion = Product.Promotion,
                PromotionDescription = Product.PromotionDescription,
                StockQuantity = Product.StockQuantity,
                BasketQuantity = Product.BasketQuantity
            };

            return response;
        }

        private A.Domain.Models.Product MapRequestToProduct(ProductUpdateRequest request)
        {
            var response = new A.Domain.Models.Product() {
                Id = request.Id,
                Name = request.Data.Name,
                Brand = request.Data.Brand,
                Type = request.Data.Type,
                Description = request.Data.Description,
                UnitPrice = request.Data.UnitPrice,
                PromtionalUnitPrice = request.Data.PromtionalUnitPrice,
                ImageURL = request.Data.ImageURL,
                Promotion = request.Data.Promotion,
                PromotionDescription = request.Data.PromotionDescription,
                StockQuantity = request.Data.StockQuantity,
                BasketQuantity = request.Data.BasketQuantity
            };
            return response;
        }
    }
}