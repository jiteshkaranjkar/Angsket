using A.Domain.Models;
using A.BasketRepository.Context;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace A.BasketRepository
{
    public class BasketRepository : IBasketRepository
    {
        private BasketDBContext basketContext;

        public BasketRepository(BasketDBContext basketDbContext)
        {
            basketContext = basketDbContext;
        }

        public async Task<Basket> GetBasketByIdAsync(string buyerId)
        {
            return await basketContext.Basket.Where(b => b.Buyerid == buyerId).FirstOrDefaultAsync();
        }

        public async Task<Basket> UpdateBasketAsync(Basket basket)
        {
            return await  basketContext.Basket.Where(b => b.Buyerid == basket.Buyerid).FirstOrDefaultAsync();
        }

        public bool DeleteBasket()
        {
            throw new NotImplementedException();
        }
    }
}