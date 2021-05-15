﻿using System.Linq;
using DeliveryService.Interfaces;
using DeliveryService.Models;

namespace DeliveryService.UI
{
    public class Controller : IControllable
    {
        private readonly IStorable _storage;

        public Controller(IStorable storage)
        {
            _storage = storage;
        }

        public IStorable GetStorage()
        {
            return _storage;
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
    }
}
