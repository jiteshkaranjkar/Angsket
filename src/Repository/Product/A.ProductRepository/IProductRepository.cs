using A.Domain.Models;
using System.Collections.Generic;

namespace A.ProductRepository
{
  public interface IProductRepository
  {
    List<Product> GetAllProducts();

    Product GetProductById(int id);
  }
}
