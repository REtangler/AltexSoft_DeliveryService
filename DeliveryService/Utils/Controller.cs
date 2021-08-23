/*using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Diagnostics;
using AltexFood_Delivery.BLL.Interfaces;
using AltexFood_Delivery.BLL.Models;

namespace AltexFood_Delivery.BLL.Utils
{
    public class Controller : IControllable
    {
        private readonly IStorable _storage;
        private readonly ISerializable _serializer;
        private readonly ICurrencyRetriever _currencyRetriever;
        private readonly ICacheable _cache;

        private readonly Action<string> _debugHandler;

        public Controller(IStorable storage, ISerializable serializer, ICurrencyRetriever currencyRetriever, ICacheable cache)
        {
            _cache = cache;
            _storage = storage;
            _serializer = serializer;
            _currencyRetriever = currencyRetriever;
            _debugHandler = listName => { Debug.WriteLine($"{listName} was added to cache"); };
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
            var orders = _cache.GetObjectFromCache<Order>();
            if (orders != null) 
                return orders;

            _cache.AddObjectToCache(_storage.Orders, _debugHandler);
            return _storage.Orders;
        }

        public IEnumerable<PcPeripheral> GetPcPeripherals()
        {
            var peripherals = _cache.GetObjectFromCache<PcPeripheral>();
            if (peripherals != null) 
                return peripherals;

            _cache.AddObjectToCache(_storage.PcPeripherals, _debugHandler);
            return _storage.PcPeripherals;
        }

        public IEnumerable<PcPart> GetPcParts()
        {
            var parts = _cache.GetObjectFromCache<PcPart>();
            if (parts != null) 
                return parts;

            _cache.AddObjectToCache(_storage.PcParts, _debugHandler);
            return _storage.PcParts;
        }

        public async Task<decimal> ConvertUahTo(decimal money, string convertTo)
        {
            var exchangeRate = await _currencyRetriever.GetExchangeRatesAsync(convertTo);

            return money * exchangeRate;
        }

        public Task<IList<string>> GetAllCurrencies()
        {
            return _currencyRetriever.GetAllCurrencies();
        }
    }
}
*/