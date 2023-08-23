using A.Domain.Models;
using System.Collections.Generic;


namespace A.BasketRepository
{
    public interface IBasketRepository
    {
        List<Basket> GetAllBaskets();

        Basket GetBasketById(string id);
    }
}
