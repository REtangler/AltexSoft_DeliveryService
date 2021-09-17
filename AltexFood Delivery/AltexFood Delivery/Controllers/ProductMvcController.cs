using System;
using AltexFood_Delivery.Api.Filters;
using AltexFood_Delivery.BLL.Services;
using AltexFood_Delivery.DAL.Interfaces;
using AltexFood_Delivery.DAL.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace AltexFood_Delivery.Api.Controllers
{
    [Route("mvc/Product")]
    public class ProductMvcController : Controller
    {
        private readonly ProductService _productService;
        private readonly IWebHostEnvironment _env;

        public ProductMvcController(ProductService productService, IWebHostEnvironment env)
        {
            _productService = productService;
            _env = env;
        }

        [HttpGet]
        [ServiceFilter(typeof(ConsoleLogActionFilter))]
        public IActionResult Index()
        {
            ViewBag.Dev = false;
            if (_env.IsDevelopment())
                ViewBag.Dev = true;
            return View(_productService.GetProducts());
        }

        [HttpGet("{id}")]
        [ResponseCache(Duration = 120, Location = ResponseCacheLocation.Any)]
        public IActionResult GetProduct(int id)
        {
            return View(_productService.GetProduct(id));
        }

        [HttpGet("add")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("add")]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
                return View();

            _productService.AddProduct(product);
            return RedirectToAction("Index");
        }

        [HttpGet("edit")]
        public IActionResult Edit(int id)
        {
            var product = _productService.GetProduct(id);
            if (product is not null)
                return View(product);
            return NotFound();
        }

        [HttpPost("edit")]
        public IActionResult Edit(Product product)
        {
            if (!ModelState.IsValid)
                return View();

            _productService.UpdateProduct(product);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var product = _productService.GetProduct(id);
            if (product is null)
                return NotFound();

            _productService.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}
