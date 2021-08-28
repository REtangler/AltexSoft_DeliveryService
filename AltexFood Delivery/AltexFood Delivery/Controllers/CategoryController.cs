using System.Collections.Generic;
using AltexFood_Delivery.BLL.Services;
using AltexFood_Delivery.DAL.Interfaces;
using AltexFood_Delivery.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace AltexFood_Delivery.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _cs;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(CategoryService cs, IUnitOfWork unitOfWork)
        {
            _cs = cs;
            _unitOfWork = unitOfWork;
        }

        // GET categories
        [HttpGet]
        public IEnumerable<Category> GetCategories()
        {
            return _cs.GetCategories();
        }

        // GET category by id
        [HttpGet("{id}")]
        public Category GetCategory(int id)
        {
            return _cs.GetCategory(id);
        }

        // POST category
        [HttpPost]
        public Category AddCategory(string name, string description)
        {
            var category = _cs.AddCategory(name, description);
            _unitOfWork.Commit();
            return category;
        }

        // DELETE category
        [HttpDelete]
        public Category DeleteCategory(int id)
        {
            var category = _cs.DeleteCategory(id);
            _unitOfWork.Commit();
            return category;
        }

        // PUT update category
        [HttpPut]
        public Category UpdateCategory(int id, string name, string description)
        {
            var category = _cs.UpdateCategory(id, name, description);
            _unitOfWork.Commit();
            return category;
        }
    }
}
