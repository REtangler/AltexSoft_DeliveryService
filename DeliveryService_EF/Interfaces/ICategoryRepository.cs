using AltexFood_Delivery.DAL.Models;

namespace AltexFood_Delivery.DAL.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Category AddCategory(Category category);
    }
}
