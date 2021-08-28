using AltexFood_Delivery.DAL.Data;
using AltexFood_Delivery.DAL.Interfaces;
using AltexFood_Delivery.DAL.Models;

namespace AltexFood_Delivery.DAL.Repos
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbFactory dbFactory) : base(dbFactory)
        {

        }

        public Category NewCategory(string name, string description)
        {
            var category = new Category
            {
                Name = name,
                Description = description
            };
            Add(category);
            return category;
        }
    }
}
