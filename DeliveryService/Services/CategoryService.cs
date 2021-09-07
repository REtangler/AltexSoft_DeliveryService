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

        public Category AddCategory(Category category)
        {
            return _categoryRepository.AddCategory(category);
        }

        public Category DeleteCategory(int id)
        {
            var category = _db.Categories.SingleOrDefault(c => c.Id == id);
            if (category is not null)
                _categoryRepository.Delete(category);
            return category;
        }

        public Category UpdateCategory(Category category)
        {
            var updatedCategory = _db.Categories.SingleOrDefault(c => c.Id == category.Id);
            if (updatedCategory is not null)
            {
                if (!(category.Name is null || category.Name.Equals("")))
                    updatedCategory.Name = category.Name;
                if (!(category.Description is null || category.Description.Equals("")))
                    updatedCategory.Description = category.Description;
                _categoryRepository.Update(updatedCategory);
            }
            return updatedCategory;
        }
    }
}
