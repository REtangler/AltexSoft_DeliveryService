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
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IEnumerable<Category> GetCategories()
        {
            return _categoryService.GetCategories();
        }

        [HttpGet("{id}")]
        public Category GetCategory(int id)
        {
            return _categoryService.GetCategory(id);
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            var addedCategory = _categoryService.AddCategory(category);
            return addedCategory is null ? (IActionResult) BadRequest() : Ok();
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var deletedCategory = _categoryService.DeleteCategory(id);
            return deletedCategory is null ? (IActionResult) BadRequest() : Ok();
        }

        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        {
            var updatedCategory = _categoryService.UpdateCategory(category);
            return updatedCategory is null ? (IActionResult) BadRequest() : Ok();
        }
    }
}
