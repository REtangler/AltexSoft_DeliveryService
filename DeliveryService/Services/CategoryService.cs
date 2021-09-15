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
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(DataContext db, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _db = db;
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
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
            var addedCategory = _categoryRepository.AddCategory(category);
            _unitOfWork.Commit();
            return addedCategory;
        }

        public Category DeleteCategory(int id)
        {
            var category = _db.Categories.SingleOrDefault(c => c.Id == id);
            if (category is not null)
                _categoryRepository.Delete(category);
            _unitOfWork.Commit();
            return category;
        }

        public Category UpdateCategory(Category category)
        {
            var updatedCategory = _db.Categories.SingleOrDefault(c => c.Id == category.Id);
            if (updatedCategory is not null)
            {
                if (!string.IsNullOrEmpty(category.Name))
                    updatedCategory.Name = category.Name;
                if (!string.IsNullOrEmpty(category.Description))
                    updatedCategory.Description = category.Description;
                _categoryRepository.Update(updatedCategory);
                _unitOfWork.Commit();
            }
            return updatedCategory;
        }
    }
}
