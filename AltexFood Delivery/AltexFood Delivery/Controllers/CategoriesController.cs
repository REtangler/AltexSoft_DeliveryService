using System.Collections.Generic;
using AltexFood_Delivery.BLL.Utils;
using AltexFood_Delivery.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace AltexFood_Delivery.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoriesService _controller;
        public CategoriesController(CategoriesService controller)
        {
            _controller = controller;
        }

        // GET products
        [HttpGet]
        public IEnumerable<Category> GetCategories()
        {
            return _controller.GetCategories();
        }

        // GET product by id
        [HttpGet("{id}")]
        public Category GetCategory(int id)
        {
            return _controller.GetCategory(id);
        }
    }
}
