using System.Collections.Generic;
using System.Text;
using DeliveryService.Interfaces;
using DeliveryService.Models;

namespace DeliveryService.UI
{
    public class Presenter : IPresentable
    {
        public string ShowActiveOrders(IList<Order> orders)
        {
            if (orders.Count is 0)
            {
                return "There are no active orders!";
            }

            var sb = new StringBuilder();

            foreach (var order in orders)
            {
                sb.Append($"Order Id #{order.Id}\n" +
                          $"Address: {order.Address}\n" +
                          $"Phone Number: {order.PhoneNumber}\n" +
                          $"Full price: {order.FullPrice}\n\n");
            }

            return sb.ToString();
        }

        public string ShowOrder(Order order)
        {
            if (order.FullPrice == default)
            {
                return "Your order is empty!";
            }

            var sb = new StringBuilder();

            sb.Append($"Order Id: {order.Id}\n");

            if (order.PcParts.Count > 0)
            {
                for (int i = 0; i < order.PcParts.Count; i++)
                {
                    var pcPart = order.PcParts[i];

                    sb.Append($"PC part #{i + 1}\n" +
                              $"Id: {pcPart.Id}\n" +
                              $"Name: {pcPart.Name}\n" +
                              $"Category: {pcPart.Category}\n" +
                              $"Price: {pcPart.Price}\n" +
                              $"Manufacturer: {pcPart.Manufacturer}\n");
                }

                sb.Append("----------END OF PC PARTS LIST----------\n");
            }

            if (order.PcPeripherals.Count > 0)
            {
                for (int i = 0; i < order.PcPeripherals.Count; i++)
                {
                    var pcPeripheral = order.PcPeripherals[i];

                    sb.Append($"PC peripheral #{i + 1}\n" +
                              $"Id: {pcPeripheral.Id}\n" +
                              $"Name: {pcPeripheral.Name}\n" +
                              $"Category: {pcPeripheral.Category}\n" +
                              $"Price: {pcPeripheral.Price}\n" +
                              $"Manufacturer: {pcPeripheral.Manufacturer}\n");
                }
                sb.Append("----------END OF PC PERIPHERALS LIST----------\n");
            }

            sb.Append($"Address: {order.Address}\n");
            sb.Append($"Phone Number: {order.PhoneNumber}\n");
            sb.Append($"Total price: {order.FullPrice}");

            return sb.ToString();
        }

        public string ShowPcPeripherals(IList<PcPeripheral> pcPeripherals)
        {
            var sb = new StringBuilder();

            foreach (var pcPeripheral in pcPeripherals)
            {
                sb.Append($"Id: {pcPeripheral.Id}\n" +
                          $"Name: {pcPeripheral.Name}\n" +
                          $"Category: {pcPeripheral.Category}\n" +
                          $"Price: {pcPeripheral.Price}\n" +
                          $"Manufacturer: {pcPeripheral.Manufacturer}\n" +
                          $"Amount: {pcPeripheral.Amount}\n");
            }
            sb.Append("----------END OF LIST----------\n");

            return sb.ToString();
        }

        public string ShowPcParts(IList<PcPart> pcParts)
        {
            var sb = new StringBuilder();

            foreach (var pcPart in pcParts)
            {
                sb.Append($"Id: {pcPart.Id}\n" +
                          $"Name: {pcPart.Name}\n" +
                          $"Category: {pcPart.Category}\n" +
                          $"Price: {pcPart.Price}\n" +
                          $"Manufacturer: {pcPart.Manufacturer}\n" +
                          $"Amount: {pcPart.Amount}\n");
            }
            sb.Append("----------END OF LIST----------\n");

            return sb.ToString();
        }
    }
}
