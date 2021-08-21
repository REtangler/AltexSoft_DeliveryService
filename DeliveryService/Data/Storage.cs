using System.Collections.Generic;
using AltexFood_Delivery.BLL.Interfaces;
using AltexFood_Delivery.BLL.Models;

namespace AltexFood_Delivery.BLL.Data
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
