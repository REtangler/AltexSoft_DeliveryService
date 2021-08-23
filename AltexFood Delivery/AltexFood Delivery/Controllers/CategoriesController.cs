using System.Collections.Generic;
using AltexFood_Delivery.BLL.Services;
using AltexFood_Delivery.DAL.Interfaces;
using AltexFood_Delivery.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace AltexFood_Delivery.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoriesService _controller;
        private readonly IUnitOfWork _unitOfWork;

        public CategoriesController(CategoriesService controller, IUnitOfWork unitOfWork)
        {
            _controller = controller;
            _unitOfWork = unitOfWork;
        }

        // GET categories
        [HttpGet]
        public IEnumerable<Category> GetCategories()
        {
            return _controller.GetCategories();
        }

        // GET category by id
        [HttpGet("{id}")]
        public Category GetCategory(int id)
        {
            return _controller.GetCategory(id);
        }

        // POST category
        [HttpPost]
        public Category AddCategory(string name, string description)
        {
            var category = _controller.AddCategory(name, description);
            _unitOfWork.Commit();
            return category;
        }

        // DELETE category
        [HttpDelete]
        public Category DeleteCategory(int id)
        {
            var category = _controller.DeleteCategory(id);
            _unitOfWork.Commit();
            return category;
        }

        // PUT update category
        [HttpPut]
        public Category UpdateCategory(int id, string name, string description)
        {
            var category = _controller.UpdateCategory(id, name, description);
            _unitOfWork.Commit();
            return category;
        }
    }
}
