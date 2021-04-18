using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService
{
    public class Order
    {
        public int Id { get; set; }

        public IList<PcPart> PcParts { get; set; }

        public IList<PcPeripheral> PcPeripherals { get; set; }

        public decimal FullPrice { get; set; }
    }
}
