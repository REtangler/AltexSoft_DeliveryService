using System.Collections.Generic;
using System.Linq;

namespace AltexFood_Delivery.DAL.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string WebAddress { get; set; }

        public static IList<Supplier> GetSuppliers()
        {
            return new List<Supplier>
            {
                new Supplier
                {
                    Id = 1,
                    Name = "Rozetka",
                    Address = "Rozetka st. 214",
                    Email = "rozetkabusiness@rozetkamail.ua",
                    ContactNumber = "+380275568258",
                    WebAddress = "www.rozetka.ua"
                },
                new Supplier
                {
                    Id = 2,
                    Name = "Prom",
                    Address = "Prom rd. 13",
                    Email = "prombusiness@prommail.ua",
                    ContactNumber = "+380457122523",
                    WebAddress = "www.prom.ua"
                }
            };
        }

        public static Supplier GetSupplier(int id)
        {
            return GetSuppliers().SingleOrDefault(x => x.Id == id);
        }
    }
}
