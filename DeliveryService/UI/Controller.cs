using System.Collections.Generic;
using System.Linq;
using DeliveryService.Interfaces;
using DeliveryService.Models;

namespace DeliveryService.UI
{
    public class Controller : IControllable
    {
        private readonly IStorable _storage;
        private readonly ISerializable _serializer;

        public Controller(IStorable storage, ISerializable serializer)
        {
            _storage = storage;
            _serializer = serializer;
        }

        public void AddPcPartToDb(IProduceable product)
        {
            var pcPart = (PcPart)product;
            pcPart.Id = _storage.PcParts.Count == 0 ? 0 : _storage.PcParts.Max(x => x.Id) + 1;
            _storage.PcParts.Add(pcPart);
            _serializer.SerializeAndSave(_storage);
        }

        public void AddPcPeripheralToDb(IProduceable product)
        {
            var pcPeripheral = (PcPeripheral)product;
            pcPeripheral.Id = _storage.PcPeripherals.Count == 0 ? 0 : _storage.PcPeripherals.Max(x => x.Id) + 1;
            _storage.PcPeripherals.Add(pcPeripheral);
            _serializer.SerializeAndSave(_storage);
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
            {
                _storage.Orders.RemoveAt(orderId);
                return;
            }

            _serializer.SerializeAndSave(_storage);
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

        public IList<Order> GetOrders()
        {
            return _storage.Orders;
        }

        public IEnumerable<PcPeripheral> GetPcPeripherals()
        {
            return _storage.PcPeripherals;
        }

        public IEnumerable<PcPart> GetPcParts()
        {
            return _storage.PcParts;
        }
    }
}
