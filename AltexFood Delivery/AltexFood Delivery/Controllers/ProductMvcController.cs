using AltexFood_Delivery.BLL.Services;
using AltexFood_Delivery.DAL.Interfaces;
using AltexFood_Delivery.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace AltexFood_Delivery.Api.Controllers
{
    [Route("mvc/Product")]
    public class ProductMvcController : Controller
    {
        private readonly ProductService _productService;
        private readonly IUnitOfWork _unitOfWork;

        public ProductMvcController(ProductService productService, IUnitOfWork unitOfWork)
        {
            _productService = productService;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_productService.GetProducts());
        }

        [HttpGet("{id}")]
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
            _unitOfWork.Commit();
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
            _unitOfWork.Commit();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var product = _productService.GetProduct(id);
            if (product is null)
                return NotFound();

            _productService.DeleteProduct(id);
            _unitOfWork.Commit();
            return RedirectToAction("Index");
        }
    }
}
