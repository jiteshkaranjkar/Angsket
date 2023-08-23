using A.Domain.Models;
using A.ProductRepository.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace A.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private ProductDBContext _context;

        public ProductRepository(ProductDBContext context)
        {
            _context = context;
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.Local.ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.Where(prod => prod.Id == id).FirstOrDefault();
        }
    }
}