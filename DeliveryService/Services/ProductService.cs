using System.Collections.Generic;
using System.Linq;
using AltexFood_Delivery.DAL.Data;
using AltexFood_Delivery.DAL.Interfaces;
using AltexFood_Delivery.DAL.Models;

namespace AltexFood_Delivery.BLL.Services
{
    public class ProductService
    {
        private readonly DataContext _db;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(DataContext db, IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _db = db;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Product> GetProducts()
        {
            IEnumerable<Product> products = _db.Products;
            IEnumerable<Category> categories = _db.Categories;
            IEnumerable<Supplier> suppliers = _db.Suppliers;
            foreach (var product in products)
            {
                product.Category = categories.Single(c => c.Id == product.CategoryId);
                product.Supplier = suppliers.Single(s => s.Id == product.SupplierId);
            }
            return products;
        }

        public Product GetProduct(int id)
        {
            var product = _db.Products.SingleOrDefault(p => p.Id == id);
            if (product is not null)
            {
                product.Category = _db.Categories.Single(c => c.Id == product.CategoryId);
                product.Supplier = _db.Suppliers.Single(s => s.Id == product.SupplierId);
            }

            return product;
        }

        public Product AddProduct(Product product)
        {
            var addedProduct = _productRepository.AddProduct(product);
            _unitOfWork.Commit();
            return addedProduct;
        }

        public Product DeleteProduct(int id)
        {
            var product = _db.Products.SingleOrDefault(p => p.Id == id);
            if (product is not null)
                _productRepository.Delete(product);
            _unitOfWork.Commit();
            return product;
        }

        public Product UpdateProduct(Product product)
        {
            _productRepository.Update(product);
            _unitOfWork.Commit();
            return product;
        }
    }
}
