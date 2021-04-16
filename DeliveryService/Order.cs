using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService
{
    class Order
    {
        public int Id { get; set; }

        public List<PcPart> PcParts { get; set; }

        public List<PcPeripheral> PcPeripherals { get; set; }

        public decimal FullPrice { get; set; }
    }
}
