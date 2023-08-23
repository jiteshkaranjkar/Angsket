using A.Domain.Common;
using A.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace A.OrderRepository.Context
{
    public class OrderDBContextSeeder
    {
        public void Seed(OrderDBContext dbContext)
        {
            List<Product> products = MakeProducts();
            Order order1 = new()
            {
                OrderNumber = 1,
                OrderItems = new List<OrderItem>()
                {
                    new OrderItem(3) { Product = products[0] },
                    new OrderItem(2) { Product = products[0] },
                    new OrderItem(1) { Product = products[0] },
                },
                Status = OrderStatus.InProgress
            };
            dbContext.Orders.Add(order1);

            Order order2 = new()
            {
                OrderNumber = 2,
                OrderItems = new List<OrderItem>()
                {
                    new OrderItem(2) { Product = products[0] },
                    new OrderItem(3) { Product = products[2] },
                    new OrderItem(1) { Product = products[1] },
                },
                Status = OrderStatus.InProgress
            };
            dbContext.Orders.Add(order2);
        }

        private List<Product> MakeProducts()
        {
            return new List<Product>() {
                new Product()
                {
                    Brand = CommonConstants.COOPERS_BRAND,
                    Name = CommonConstants.COOPERS_NAME,
                    Type = "Pale Ale",
                    Description = "One of Australia's finest family-brewed beers, Coopers Pale Ale is a crisp, cloudy and refreshing bottle-fermented Australian pale.",
                    Promotion = CommonConstants.COOPERS_PROMOTIONAL_OFFER,
                    PromotionDescription = "(Buy one and get one free)",
                    ImageURL = CommonConstants.COOPERS_IMAGE_URL,
                    UnitPrice = 20.49
                },
                new Product()
                {
                    Brand = CommonConstants.CROWN_BRAND,
                    Name = CommonConstants.CROWN_NAME,
                    Type = "Lager",
                    Description = "A full flavoured classic premium Australian lager brewed with 100% Australian malt, first choice hops and only the finest natural ingredients locally sourced.",
                    Promotion = "",
                    PromotionDescription = "",
                    ImageURL = CommonConstants.CROWN_IMAGE_URL,
                    UnitPrice = 22.99
                },
                new Product()
                {
                    Brand = CommonConstants.TOOHEYS_BRAND,
                    Name = CommonConstants.TOOHEYS_NAME,
                    Type = "Extra Dry Australian Lager",
                    Description = "The Tooheys brothers’ pursuit of refreshing beers suited to the Australian climate was embodied by the clean, crisp taste of Tooheys Extra Dry.",
                    Promotion = "",
                    PromotionDescription = "",
                    ImageURL = CommonConstants.TOOHEYS_IMAGE_URL,
                    UnitPrice = 19.99
                },
                new Product()
                {
                    Brand = CommonConstants.VB_BRAND,
                    Name = CommonConstants.VB_NAME,
                    Type = "Lager",
                    Description = "Victoria Bitter is a full flavoured, full strength beer; the gentle fruitiness of the aroma complements the sweet maltiness in the mouth which in turn balances perfectly with the clean hop bitterness of the finish.",
                    Promotion = CommonConstants.VB_PROMOTIONAL_OFFER,
                    PromotionDescription = "($2 off)",
                    ImageURL = CommonConstants.VB_IMAGE_URL,
                    UnitPrice = 21.49,
                    PromtionalUnitPrice = 19.49
                }
            };
        }
    }
}
