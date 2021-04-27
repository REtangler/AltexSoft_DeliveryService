using System.Collections.Generic;
using DeliveryService.Models;

namespace DeliveryService.Interfaces
{
    public interface IStorable
    {
        IList<PcPart> PcParts { get; set; }
        IList<PcPeripheral> PcPeripherals { get; set; }
        IList<Order> Orders { get; set; }

    }
}
