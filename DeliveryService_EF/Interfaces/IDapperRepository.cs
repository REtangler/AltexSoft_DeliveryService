using System.Collections.Generic;
using AltexFood_Delivery.DAL.Models;

namespace AltexFood_Delivery.DAL.Interfaces
{
    interface IDapperRepository
    {
        IList<Product> GetProducts();
        IList<Product> GetProductsNested();
        Product GetProductById(int id);
        Product GetProductByIdNested(int id);
        Product AddProduct(Product product);
        Product AddProductNested(Product product, Category category);
        Product UpdateProduct(int id, int amountInStock);
        Product UpdateProductNested(int id, Category category);
        Product DeleteProduct(int id);
        IList<Product> DeleteProductNested(int categoryId);
    }
}
