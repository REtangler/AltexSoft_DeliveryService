using System.Collections.Generic;
using System.Linq;
using Dapper.Contrib.Extensions;

namespace DeliveryService_EF.Models
{
    [Table("Categories")]
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public static IList<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category
                {
                    Id = 1,
                    Name = "GPU",
                    Description = "Category dedicated to - Graphics Processing Units"
                },
                new Category
                {
                    Id = 2,
                    Name = "CPU",
                    Description = "Category dedicated to - Central Processing Units"
                },
                new Category
                {
                    Id = 3,
                    Name = "MB",
                    Description = "Category dedicated to - Motherboards"
                }
            };
        }

        public static Category GetCategory(int id)
        {
            return GetCategories().SingleOrDefault(x => x.Id == id);
        }
    }
}
