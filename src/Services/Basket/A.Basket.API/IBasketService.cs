using A.Domain.Models;
using System.Collections.Generic;

namespace A.BasketService.API
{
    public interface IBasketService
    {
        Basket GetBasketById(string buyerid);

        Basket UpdateBasket(Basket basket);
    }
}
