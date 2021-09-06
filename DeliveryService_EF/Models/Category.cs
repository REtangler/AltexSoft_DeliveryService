using System.Collections.Generic;
using System.Linq;
using Dapper.Contrib.Extensions;

namespace AltexFood_Delivery.DAL.Models
{
    [Table("Categories")]
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
