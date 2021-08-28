using System.Collections.Generic;
using System.Linq;
using AltexFood_Delivery.DAL.Data;
using AltexFood_Delivery.DAL.Interfaces;
using AltexFood_Delivery.DAL.Models;

namespace AltexFood_Delivery.BLL.Services
{
    public class CategoryService
    {
        private readonly DataContext _db;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(DataContext db, ICategoryRepository categoryRepository)
        {
            _db = db;
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _db.Categories;
        }

        public Category GetCategory(int id)
        {
            return _db.Categories.SingleOrDefault(c => c.Id == id);
        }

        public Category AddCategory(string name, string description)
        {
            return _categoryRepository.NewCategory(name, description);
        }

        public Category DeleteCategory(int id)
        {
            var category = _db.Categories.SingleOrDefault(c => c.Id == id);
            if (category is not null)
                _categoryRepository.Delete(category);
            return category;
        }

        public Category UpdateCategory(int id, string name, string description)
        {
            var category = _db.Categories.SingleOrDefault(c => c.Id == id);
            if (category is not null)
            {
                if (!(name is null || name.Equals("")))
                    category.Name = name;
                if (!(description is null || description.Equals("")))
                    category.Description = description;
                _categoryRepository.Update(category);
            }
            return category;
        }
    }
}
