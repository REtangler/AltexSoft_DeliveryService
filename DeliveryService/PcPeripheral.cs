using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService
{
    public class PcPeripheral : IProduceable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public decimal Price { get; set; }

        public string Manufacturer { get; set; }

        public void CreateProduct(int id, string name, decimal price, string manufacturer, string category)
        {
            Id = id;
            Name = name;
            Category = category;
            Price = price;
            Manufacturer = manufacturer;
        }
    }
}
