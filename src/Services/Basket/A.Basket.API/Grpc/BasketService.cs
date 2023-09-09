using A.BasketRepository;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;

namespace GrpcBasket
{
    public class BasketService : Basket.BasketBase
    {
        private IBasketRepository basketRepository;
        private readonly ILogger<BasketService> _logger;

        public BasketService(IBasketRepository repository, ILogger<BasketService> logger)
        {
            basketRepository = repository;
        }

        [AllowAnonymous]
        public override async Task<BasketResponse> GetBasketByIdAsync(BasketRequest request, ServerCallContext context)
        {
            _logger.LogInformation($"Begin grpc call from method {context.Method} for basket id {request.Buyerid}");
            var basket = await basketRepository.GetBasketByIdAsync(request.Buyerid);
            if (basket != null)
            {
                context.Status = new Status(StatusCode.OK, $"Basket with buyerId {request.Buyerid} exists");
                return MapToBasketResponse(basket);
            }
            else
            {
                context.Status = new Status(StatusCode.NotFound, $"Basket with Buyerid {request.Buyerid} do not exist");
            }
            return new BasketResponse();
        }

        public override async Task<BasketResponse> UpdateBasketAsync(BasketUpdateRequest request, ServerCallContext context)
        {
            _logger.LogInformation($"Begin grpc call BasketService.UpdateBasketAsync for buyer id {request.Buyerid}");

            var BuyerBasket = MapToBuyerBasket(request);

            var basket = await basketRepository.UpdateBasketAsync(BuyerBasket);
            if (basket != null)
            {
                context.Status = new Status(StatusCode.OK, $"Basket with buyerId {request.Buyerid} exists");
                return MapToBasketResponse(basket);
            }
            context.Status = new Status(StatusCode.NotFound, $"Basket with buyer id {request.Buyerid} do not exist");

            return null;
        }

        private BasketResponse MapToBasketResponse(A.Domain.Models.Basket basket)
        {
            var response = new BasketResponse
            {
                Buyerid = basket.Buyerid
            };

            basket.Items.ForEach(item => response.Items.Add(new ProductResponse
            {
                Id = item.Id,
                Name = item.Name,
                Brand = item.Brand,
                Type = item.Type,
                Description = item.Description,
                UnitPrice = item.UnitPrice,
                PromtionalUnitPrice = item.PromtionalUnitPrice,
                ImageURL = item.ImageURL,
                Promotion = item.Promotion,
                PromotionDescription = item.PromotionDescription,
                StockQuantity = item.StockQuantity,
                BasketQuantity = item.BasketQuantity
            }));

            return response;
        }

        private A.Domain.Models.Basket MapToBuyerBasket(BasketUpdateRequest request)
        {
            var response = new A.Domain.Models.Basket(request.Buyerid);

            request.Items.ToList().ForEach(item => response.Items.Add(new A.Domain.Models.Product
            {
                Id = item.Id,
                Name = item.Name,
                Brand = item.Brand,
                Type = item.Type,
                Description = item.Description,
                UnitPrice = item.UnitPrice,
                PromtionalUnitPrice = item.PromtionalUnitPrice,
                ImageURL = item.ImageURL,
                Promotion = item.Promotion,
                PromotionDescription = item.PromotionDescription,
                StockQuantity = item.StockQuantity,
                BasketQuantity = item.BasketQuantity
            }));

            return response;
        }
    }
}