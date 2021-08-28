using System.Collections.Generic;
using AltexFood_Delivery.BLL.Services;
using AltexFood_Delivery.DAL.Interfaces;
using AltexFood_Delivery.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace AltexFood_Delivery.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _ps;
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(ProductService ps, IUnitOfWork unitOfWork)
        {
            _ps = ps;
            _unitOfWork = unitOfWork;
        }

        // GET Products
        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return _ps.GetProducts();
        }

        // GET Product by id
        [HttpGet("{id}")]
        public Product GetProduct(int id)
        {
            return _ps.GetProduct(id);
        }

        // POST Product
        [HttpPost]
        public Product AddProduct(Product product)
        {
            var addedProduct = _ps.AddProduct(product);
            _unitOfWork.Commit();
            return addedProduct;
        }

        // DELETE Product
        [HttpDelete]
        public Product DeleteProduct(int id)
        {
            var product = _ps.DeleteProduct(id);
            _unitOfWork.Commit();
            return product;
        }

        // PUT update Product
        [HttpPut]
        public Product UpdateProduct(Product product)
        {
            var updatedProduct = _ps.UpdateProduct(product);
            _unitOfWork.Commit();
            return updatedProduct;
        }
    }
}
