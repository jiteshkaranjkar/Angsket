using A.BasketRepository;
using A.Domain.Models;
using System.Collections.Generic;

namespace A.BasketService.API
{
    public class BasketService : IBasketService
    {
        private IBasketRepository BasketRepository;

        public BasketService(IBasketRepository BasketRepo)
        {
            BasketRepository = BasketRepo;
        }

        public List<Basket> GetAllBasket()
        {
            return BasketRepository.GetAllBaskets();
        }

        public Basket GetBasketById(string id)
        {
            return BasketRepository.GetBasketById(id);
        }
    }
}