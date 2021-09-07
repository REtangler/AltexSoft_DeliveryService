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
        public Category AddCategory(Category category)
        {
            return _categoryService.AddCategory(category);
        }

        [HttpDelete]
        public Category DeleteCategory(int id)
        {
            return _categoryService.DeleteCategory(id);
        }

        [HttpPut]
        public Category UpdateCategory(Category category)
        {
            return _categoryService.UpdateCategory(category);
        }
    }
}
