using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltexFood_Delivery.BLL.Services;
using AltexFood_Delivery.DAL.Data;
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

        [HttpGet]
        public IActionResult Index()
        {
            return View(_ps.GetProducts());
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            return View(_ps.GetProduct(id));
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

            _ps.AddProduct(product);
            _unitOfWork.Commit();
            return RedirectToAction("Index");
        }

        [HttpGet("edit")]
        public IActionResult Edit(int id)
        {
            var product = _ps.GetProduct(id);
            if (product is not null)
                return View(product);
            return NotFound();
        }

        [HttpPost("edit")]
        public IActionResult Edit(Product product)
        {
            if (!ModelState.IsValid)
                return View();

            _ps.UpdateProduct(product);
            _unitOfWork.Commit();
            return RedirectToAction("Index");
        }

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
