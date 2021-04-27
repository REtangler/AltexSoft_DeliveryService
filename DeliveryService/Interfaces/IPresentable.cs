using System.Collections.Generic;
using DeliveryService.Models;

namespace DeliveryService.Interfaces
{
    public interface IPresentable
    {
        string ShowActiveOrders(List<Order> orders);
        string ShowOrder(Order order);
        string ShowPcPeripherals(List<PcPeripheral> pcPeripherals);
        string ShowPcParts(List<PcPart> pcParts);
    }
}
