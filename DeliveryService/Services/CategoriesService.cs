using System.Collections.Generic;
using System.Linq;
using AltexFood_Delivery.DAL.Data;
using AltexFood_Delivery.DAL.Models;

namespace AltexFood_Delivery.BLL.Utils
{
    public class CategoriesService
    {
        private readonly DataContext _db;

        public CategoriesService(DataContext db)
        {
            _db = db;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _db.Categories;
        }

        public Category GetCategory(int id)
        {
            return _db.Categories.SingleOrDefault(c => c.Id == id);
        }
    }
}
