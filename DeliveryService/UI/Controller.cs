﻿using System.Linq;
using System.Text;
using DeliveryService.Interfaces;
using DeliveryService.Models;

namespace DeliveryService.UI
{
    public class Controller : IControllable, IItemPresentable
    {
        private readonly IStorable _storage;

        public Controller(IStorable storage)
        {
            _storage = storage;
        }

        public void AddPcPartToDb(IProduceable product)
        {
            var pcPart = (PcPart)product;
            pcPart.Id = _storage.PcParts.Count == 0 ? 0 : _storage.PcParts.Max(x => x.Id) + 1;
            _storage.PcParts.Add(pcPart);
        }

        public void AddPcPeripheralToDb(IProduceable product)
        {
            var pcPeripheral = (PcPeripheral)product;
            pcPeripheral.Id = _storage.PcPeripherals.Count == 0 ? 0 : _storage.PcPeripherals.Max(x => x.Id) + 1;
            _storage.PcPeripherals.Add(pcPeripheral);
        }

        public void AddPcPartToOrder(int orderId, int itemId)
        {
            _storage.Orders[orderId].PcParts.Add(_storage.PcParts[itemId]);
            _storage.PcParts[itemId].Amount--;
            _storage.Orders[orderId].FullPrice = _storage.Orders[orderId].RecalculatePrice();
        }

        public void AddPcPeripheralToOrder(int orderId, int itemId)
        {
            _storage.Orders[orderId].PcPeripherals.Add(_storage.PcPeripherals[itemId]);
            _storage.PcPeripherals[itemId].Amount--;
            _storage.Orders[orderId].FullPrice = _storage.Orders[orderId].RecalculatePrice();
        }

        public void DeleteEmptyOrder(int orderId)
        {
            if (_storage.Orders[orderId].FullPrice == default)
                _storage.Orders.RemoveAt(orderId);
        }

        public Order CreateOrder(string phoneNumber, string address)
        {
            var order = new Order
            {
                Id = _storage.Orders.Count == 0 ? 0 : _storage.Orders.Max(x => x.Id) + 1,
                PhoneNumber = phoneNumber,
                Address = address
            };

            _storage.Orders.Add(order);

            return order;
        }

        public bool CanAddPcPartsToOrder(int choice)
        {
            return _storage.PcParts.Any(x => x.Id == choice) && _storage.PcParts[choice].Amount > 0;
        }

        public bool CanAddPcPeripheralsToOrder(int choice)
        {
            return _storage.PcPeripherals.Any(x => x.Id == choice) && _storage.PcPeripherals[choice].Amount > 0;
        }

        public string ShowActiveOrders()
        {
            var sb = new StringBuilder();
            if (_storage.Orders.Count is 0)
                return "There are no active orders!";
            
            foreach (var order in _storage.Orders)
            {
                sb.Append($"Order Id #{order.Id}\n" +
                                  $"Address: {order.Address}\n" +
                                  $"Phone Number: {order.PhoneNumber}\n" +
                                  $"Full price: {order.FullPrice}\n\n");
            }

            return sb.ToString();
        }

        public string ShowPcPeripherals()
        {
            var sb = new StringBuilder();
            foreach (var pcPeripheral in _storage.PcPeripherals)
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

        public string ShowPcParts()
        {
            var sb = new StringBuilder();
            foreach (var pcPart in _storage.PcParts)
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
