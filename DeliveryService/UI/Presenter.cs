using System.Collections.Generic;
using DeliveryService.Interfaces;
using DeliveryService.Models;

namespace DeliveryService.UI
{
    public class Presenter : IPresentable
    {
        public string ShowActiveOrders(IList<Order> orders)
        {
            var output = string.Empty;

            if (orders.Count is 0)
            {
                return "There are no active orders!";
            }

            foreach (var order in orders)
            {
                output += $"Order Id #{order.Id}\n" +
                          $"Full price: {order.FullPrice}\n";
            }

            return output;
        }

        public string ShowOrder(Order order)
        {
            var output = string.Empty;

            if (order.FullPrice == default)
            {
                return "Your order is empty!";
            }

            output += $"Order Id: {order.Id}\n";

            if (order.PcParts.Count > 0)
            {
                for (int i = 0; i < order.PcParts.Count; i++)
                {
                    var pcPart = order.PcParts[i];

                    output += $"PC part #{i + 1}\n" +
                              $"Id: {pcPart.Id}\n" +
                              $"Name: {pcPart.Name}\n" +
                              $"Category: {pcPart.Category}\n" +
                              $"Price: {pcPart.Price}\n" +
                              $"Manufacturer: {pcPart.Manufacturer}\n";
                }

                output += "----------END OF PC PARTS LIST----------\n";
            }

            if (order.PcPeripherals.Count > 0)
            {
                for (int i = 0; i < order.PcPeripherals.Count; i++)
                {
                    var pcPeripheral = order.PcPeripherals[i];

                    output += $"PC peripheral #{i + 1}\n" +
                              $"Id: {pcPeripheral.Id}\n" +
                              $"Name: {pcPeripheral.Name}\n" +
                              $"Category: {pcPeripheral.Category}\n" +
                              $"Price: {pcPeripheral.Price}\n" +
                              $"Manufacturer: {pcPeripheral.Manufacturer}\n";
                }
                output += "----------END OF PC PERIPHERALS LIST----------\n";
            }

            output += $"Total price: {order.FullPrice}";

            return output;
        }

        public string ShowPcPeripherals(IList<PcPeripheral> pcPeripherals)
        {
            var output = string.Empty;

            foreach (var pcPeripheral in pcPeripherals)
            {
                output += $"Id: {pcPeripheral.Id}\n" +
                          $"Name: {pcPeripheral.Name}\n" +
                          $"Category: {pcPeripheral.Category}\n" +
                          $"Price: {pcPeripheral.Price}\n" +
                          $"Manufacturer: {pcPeripheral.Manufacturer}\n" +
                          $"Amount: {pcPeripheral.Amount}\n";
            }
            output += "----------END OF LIST----------\n";

            return output;
        }

        public string ShowPcParts(IList<PcPart> pcParts)
        {
            var output = string.Empty;

            foreach (var pcPart in pcParts)
            {
                output += $"Id: {pcPart.Id}\n" +
                          $"Name: {pcPart.Name}\n" +
                          $"Category: {pcPart.Category}\n" +
                          $"Price: {pcPart.Price}\n" +
                          $"Manufacturer: {pcPart.Manufacturer}\n" +
                          $"Amount: {pcPart.Amount}\n";
            }
            output += "----------END OF LIST----------\n";

            return output;
        }
    }
}
