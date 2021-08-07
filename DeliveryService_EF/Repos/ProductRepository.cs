using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryService_EF.Data;
using DeliveryService_EF.Interfaces;
using DeliveryService_EF.Models;

namespace DeliveryService_EF.Repos
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }

        public Product NewProduct(string name, string description, decimal price, int amountInStock, int categoryId, int supplierId, string type)
        {
            var product = new Product
            {
                AmountInStock = amountInStock,
                Category = new Category(),
                CategoryId = categoryId,
                Description = description,
                Name = name,
                Price = price,
                Supplier = new Supplier(),
                SupplierId = supplierId,
                Type = type
            };
            Add(product);
            return product;
        }
    }
}
