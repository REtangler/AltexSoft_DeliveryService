using AltexFood_Delivery.DAL.Models;

namespace AltexFood_Delivery.DAL.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Product NewProduct(string name, string description, decimal price, int amountInStock, int categoryId, int supplierId, string type);
    }
}
