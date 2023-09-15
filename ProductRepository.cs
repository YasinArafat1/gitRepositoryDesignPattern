using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Final_Project
{
    public class ProductRepository : IRepository<Product>
    {
        public static List<Product> products = new List<Product>();
        public int nextId = 1;

        public Product GetById(int id)
        {
            return products.FirstOrDefault(p => p.ProductId == id);
        }

        public List<Product> GetAll()
        {
            return products;
        }

        public void Add(Product entity)
        {
            entity.ProductId = nextId++;
            products.Add(entity);
        }

        public void Update(Product entity)
        {
            var existingProduct = GetById(entity.ProductId);
            if (existingProduct != null)
            {
                existingProduct.ProductName = entity.ProductName;
                existingProduct.ProductPrice = entity.ProductPrice;
            }
        }

        public void Delete(int id)
        {
            var product = GetById(id);
            if (product != null)
            {
                products.Remove(product);
            }
        }
    }

}
