using A.Domain.Models;
using System.Collections.Generic;

namespace A.BasketService.API
{
    public interface IBasketService
    {
        List<Basket> GetAllBasket();

        Basket GetBasketById(string id);
    }
}
