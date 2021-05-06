using System;
using DeliveryService.Data;
using DeliveryService.Interfaces;

namespace DeliveryService.UI
{
    public class Controller : IControllable
    {
        private IStorable _storage;
        private readonly Presenter _presenter;

        public Controller(IStorable storage)
        {
            _storage = storage;
            _presenter = new Presenter();
        }

        public Storage Start()
        {
            while (true)
            {
                var choice = _presenter.ShowMainMenu();

                if (choice == 1)
                {
                    Console.Clear();

                    _storage = _presenter.BusinessDialogue(_storage);

                    Console.Clear();
                    continue;
                }

                if (choice == 2)
                {
                    Console.Clear();

                    int currentOrderId;
                    (_storage, currentOrderId) = _presenter.ClientDialogue(_storage);

                    if (_storage.Orders[currentOrderId].FullPrice == default)
                        _storage.Orders.RemoveAt(currentOrderId);

                    Console.Clear();
                    continue;
                }

                if (choice == 0)
                    break;
            }

            return new Storage {PcPeripherals = _storage.PcPeripherals, Orders = _storage.Orders, PcParts = _storage.PcParts};
        }
    }
}
