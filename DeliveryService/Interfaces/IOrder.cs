using System.Collections.Generic;
using AltexFood_Delivery.BLL.Models;

namespace AltexFood_Delivery.BLL.Interfaces
{
    public interface IOrder
    {
        int Id { get; set; }

        IList<PcPart> PcParts { get; set; }

        IList<PcPeripheral> PcPeripherals { get; set; }

        decimal FullPrice { get; set; }

        string Address { get; set; }

        string PhoneNumber { get; set; }
    }
}
