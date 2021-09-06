using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AltexFood_Delivery.DAL.Models;

namespace AltexFood_Delivery.DAL.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Category AddCategory(Category category);
    }
}
