using A.Domain.Models;
using A.BasketRepository.Context;
using System.Collections.Generic;
using System.Linq;

namespace A.BasketRepository
{
    public class BasketRepository : IBasketRepository
    {
        private BasketDBContext _context;

        public BasketRepository(BasketDBContext context)
        {
            _context = context;
        }

        public List<Basket> GetAllBaskets()
        {
            return _context.Baskets.Local.ToList();
        }

        public Basket GetBasketById(string basketId)
        {
            return _context.Baskets.Where(bskt => bskt.BasketId == basketId).FirstOrDefault();
        }
    }
}