using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Category AddCategory(Category category)
        {
            Add(category);
            return category;
        }
    }
}
