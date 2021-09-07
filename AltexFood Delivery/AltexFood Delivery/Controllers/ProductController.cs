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
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return _productService.GetProducts();
        }

        [HttpGet("{id}")]
        public Product GetProduct(int id)
        {
            return _productService.GetProduct(id);
        }

        [HttpPost]
        public Product AddProduct(Product product)
        {
            return _productService.AddProduct(product);
        }

        [HttpDelete]
        public Product DeleteProduct(int id)
        {
            return _productService.DeleteProduct(id);
        }

        [HttpPut]
        public Product UpdateProduct(Product product)
        {
            return _productService.UpdateProduct(product);
        }
    }
}
