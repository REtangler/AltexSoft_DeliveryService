using AltexFood_Delivery.DAL.Data;
using AltexFood_Delivery.DAL.Interfaces;
using AltexFood_Delivery.DAL.Models;

namespace AltexFood_Delivery.DAL.Repos
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
