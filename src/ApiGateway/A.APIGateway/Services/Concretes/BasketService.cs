using A.APIGateway.Models;
using A.APIGateway.Services.Contracts;
using GrpcBasket;
using System.Xml.Linq;

namespace A.APIGateway.Services.Concretes
{
    public class BasketService : IBasketService
    {
        private readonly Basket.BasketClient basketClient;
        private readonly ILogger<BasketService> logger;

        public BasketService(Basket.BasketClient basketClient, ILogger<BasketService> logger)
        {
            this.basketClient = basketClient;
            this.logger = logger;

        }

        public async Task<BasketEntity> GetBasketByIdAsync(string buyerid)
        {
            logger.LogDebug($"Grpc Client created , request = {buyerid}");
            var response = await basketClient.GetBasketByIdAsync(new BasketRequest { Buyerid = buyerid });
            logger.LogDebug($"Grpc response {response}");
            return MapToBasketEntity(response);
        }

        public async Task UpdateBasketAsync(BasketEntity basketEntity)
        {
            logger.LogDebug($"Grpc Client created , request = {basketEntity}");
            var basketRequest = MapBasketEntityToBasketRequest(basketEntity);
            var response = await basketClient.UpdateBasketAsync(basketRequest);
            logger.LogDebug($"Grpc response {response}");
        }

        private BasketEntity MapToBasketEntity(BasketResponse basketResponse)
        {
            if (basketResponse == null)
            {
                return null;
            }

            var response = new BasketEntity(basketResponse.Buyerid);

            basketResponse.Items.ToList().ForEach(item =>
            {
                if (item.Id != null)
                {
                    response.Items.Add(new ProductEntity
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
                    });
                }
            });

            return response;
        }

        private BasketUpdateRequest MapBasketEntityToBasketRequest(BasketEntity basketEntity)
        {
            if (basketEntity == null)
            {
                return null;
            }

            var request = new BasketUpdateRequest
            {
                Buyerid = basketEntity.BuyerId
            };

            basketEntity.Items.ToList().ForEach(item =>
            {
                if (item.Id != null)
                {
                    request.Items.Add(new ProductResponse
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
                    });
                }
            });
            return request;
        }
    }
}
