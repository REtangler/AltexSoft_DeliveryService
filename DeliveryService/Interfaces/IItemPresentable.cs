using System.Collections.Generic;
using DeliveryService.Models;

namespace DeliveryService.Interfaces
{
    public interface IItemPresentable
    {
        void ShowActiveOrders(IList<Order> orders);
        void ShowOrder(Order order);
        void ShowPcPeripherals(IList<PcPeripheral> pcPeripherals);
        void ShowPcParts(IList<PcPart> pcParts);
    }
}