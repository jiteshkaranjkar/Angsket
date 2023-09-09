using A.Domain.Models;
using System.Collections.Generic;


namespace A.BasketRepository
{
    public interface IBasketRepository
    {
        Task<Basket> GetBasketByIdAsync(string buyerid);
        Task<Basket> UpdateBasketAsync(Basket basket);
        bool DeleteBasket();
    }
}
