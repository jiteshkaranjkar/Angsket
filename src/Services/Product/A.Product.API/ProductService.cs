using A.Domain.Models;
using A.ProductRepository;
using System.Collections.Generic;

namespace A.ProductService.API
{
    public class ProductService : IProductService
    {
        private IProductRepository productRepository;

        public ProductService(IProductRepository productRepo)
        {
            productRepository = productRepo;
        }

        public List<Product> GetAllProducts()
        {
            return productRepository.GetAllProducts();
        }

        public Product GetProductById(int id)
        {
            return productRepository.GetProductById(id);
        }
    }
}