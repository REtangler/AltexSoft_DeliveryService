using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService
{
    class PcPeripheral : IProduceable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public PcPeripheralType PcPeripheralType { get; set; }

        public decimal Price { get; set; }

        public string Manufacturer { get; set; }

        public void CreateProduct(int id, string name, decimal price, string manufacturer, PcPartType type)
        {
            throw new Exception("Wrong parameter used! Change product type!");
        }

        public void CreateProduct(int id, string name, decimal price, string manufacturer, PcPeripheralType type)
        {
            Id = id;
            Name = name;
            PcPeripheralType = type;
            Price = price;
            Manufacturer = manufacturer;
        }

        public void DeleteProduct()
        {
            throw new NotImplementedException();
        }
    }
}
