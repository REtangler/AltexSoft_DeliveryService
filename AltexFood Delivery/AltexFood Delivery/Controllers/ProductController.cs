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
        public IActionResult AddProduct(Product product)
        {
            var addedProduct = _productService.AddProduct(product);
            return addedProduct is null ? (IActionResult) BadRequest() : Ok();
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var deletedProduct = _productService.DeleteProduct(id);
            return deletedProduct is null ? (IActionResult) BadRequest() : Ok();
        }

        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            var updatedProduct = _productService.UpdateProduct(product);
            return updatedProduct is null ? (IActionResult) BadRequest() : Ok();
        }
    }
}
