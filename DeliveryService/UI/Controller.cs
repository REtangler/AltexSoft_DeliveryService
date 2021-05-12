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

        public void SaveBusinessData(int choice, IProduceable product)
        {
            switch (choice)
            {
                case 1:
                {
                    var pcPart = (PcPart)product;
                    pcPart.Id = _storage.PcParts.Count;
                    _storage.PcParts.Add(pcPart);
                    break;
                }

                case 2:
                {
                    var pcPeripheral = (PcPeripheral)product;
                    pcPeripheral.Id = _storage.PcPeripherals.Count;
                    _storage.PcPeripherals.Add(pcPeripheral);
                    break;
                }
            }
        }

        public void SaveClientData(int choice, int orderId, int itemId)
        {
            switch (choice)
            {
                case 1:
                {
                    _storage.Orders[orderId].PcParts.Add(_storage.PcParts[itemId]);
                    _storage.PcParts[itemId].Amount--;
                    break;
                }

                case 2:
                {
                    _storage.Orders[orderId].PcPeripherals.Add(_storage.PcPeripherals[itemId]);
                    _storage.PcPeripherals[itemId].Amount--;
                    break;
                }
            }

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
                Id = _storage.Orders.Count,
                PhoneNumber = phoneNumber,
                Address = address
            };

            _storage.Orders.Add(order);

            return order;
        }
    }
}
