using System.Collections.Generic;
using DeliveryService.Models;

namespace DeliveryService.Interfaces
{
    public interface IPresentable
    {
        string ShowActiveOrders(IList<Order> orders);
        string ShowOrder(Order order);
        string ShowPcPeripherals(IList<PcPeripheral> pcPeripherals);
        string ShowPcParts(IList<PcPart> pcParts);
    }
}
