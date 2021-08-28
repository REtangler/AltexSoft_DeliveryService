using AltexFood_Delivery.BLL.Services;
using AltexFood_Delivery.DAL.Interfaces;
using AltexFood_Delivery.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace AltexFood_Delivery.Api.Controllers
{
    [Route("mvc/Product")]
    public class ProductMvcController : Controller
    {
        private readonly ProductService _ps;
        private readonly IUnitOfWork _unitOfWork;

        public ProductMvcController(ProductService ps, IUnitOfWork unitOfWork)
        {
            _ps = ps;
            _unitOfWork = unitOfWork;
        }

        // GET products
        [HttpGet]
        public IActionResult Index()
        {
            return View(_ps.GetProducts());
        }

        // GET product by id
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            return View(_ps.GetProduct(id));
        }

        // GET product creation page
        [HttpGet("add")]
        public IActionResult Create()
        {
            return View();
        }

        // POST product
        [HttpPost("add")]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
                return View();

            _ps.AddProduct(product);
            _unitOfWork.Commit();
            return RedirectToAction("Index");
        }

        // GET product edit page
        [HttpGet("edit")]
        public IActionResult Edit(int id)
        {
            var product = _ps.GetProduct(id);
            if (product is not null)
                return View(product);
            return NotFound();
        }

        // POST update product
        [HttpPost("edit")]
        public IActionResult Edit(Product product)
        {
            if (!ModelState.IsValid)
                return View();

            _ps.UpdateProduct(product);
            _unitOfWork.Commit();
            return RedirectToAction("Index");
        }

        // POST delete product
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var product = _ps.GetProduct(id);
            if (product is null)
                return NotFound();

            _ps.DeleteProduct(id);
            _unitOfWork.Commit();
            return RedirectToAction("Index");
        }
    }
}
