using System.Collections.Generic;
using AltexFood_Delivery.BLL.Models;

namespace AltexFood_Delivery.BLL.Interfaces
{
    public interface IStorable
    {
        IList<PcPart> PcParts { get; set; }
        IList<PcPeripheral> PcPeripherals { get; set; }
        IList<Order> Orders { get; set; }

    }
}
