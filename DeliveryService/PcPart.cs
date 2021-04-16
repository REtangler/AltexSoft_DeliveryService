using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService
{
    class PcPart : IProduceable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public PcPartType PcPartType { get; set; }

        public decimal Price { get; set; }

        public string Manufacturer { get; set; }

        public void CreateProduct(int id, string name, decimal price, string manufacturer, PcPartType type)
        {
            Id = id;
            Name = name;
            PcPartType = type;
            Price = price;
            Manufacturer = manufacturer;
        }

        public void CreateProduct(int id, string name, decimal price, string manufacturer, PcPeripheralType type)
        {
            throw new Exception("Wrong parameter used! Change product type!");
        }

        public void DeleteProduct()
        {
            throw new NotImplementedException();
        }
    }
}
