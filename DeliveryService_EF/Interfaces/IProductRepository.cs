using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryService_EF.Models;

namespace DeliveryService_EF.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Product NewProduct(string name, string description, decimal price, int amountInStock, int categoryId, int supplierId, string type);
    }
}
