using System.Collections.Generic;
using DeliveryService.Interfaces;
using DeliveryService.Models;

namespace DeliveryService.Data
{
    public class Storage : IStorable
    {
        public IList<PcPart> PcParts { get; set; }
        public IList<PcPeripheral> PcPeripherals { get; set; }
        public IList<Order> Orders { get; set; }

        public Storage()
        {
            PcParts = new List<PcPart>();
            PcPeripherals = new List<PcPeripheral>();
            Orders = new List<Order>();
        }
    }
}
