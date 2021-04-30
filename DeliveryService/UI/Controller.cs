using System;
using System.Collections.Generic;
using System.Linq;
using DeliveryService.Models;
using DeliveryService.Data;
using DeliveryService.Interfaces;

namespace DeliveryService.UI
{
    public class Controller : IControllable
    {
        private IStorable _storage;

        public Controller(IStorable storage)
        {
            _storage = storage;
        }

        public Storage Start()
        {
            var presenter = new Presenter();

            while (true)
            {
                Console.WriteLine("1 - Business\n" +
                                  "2 - Client\n" +
                                  "0 - Exit");
                var input = Console.ReadLine();

                if (input == string.Empty || !int.TryParse(input, out var choice))
                {
                    Console.Clear();
                    Console.WriteLine("Enter a number!");
                    continue;
                }

                var dialogue = new Dialogues();

                if (choice == 1)
                {
                    Console.Clear();

                    _storage = dialogue.BusinessDialogue(_storage);

                    Console.Clear();
                    continue;
                }

                if (choice == 2)
                {
                    Console.Clear();

                    int currentOrderId;
                    (_storage, currentOrderId) = dialogue.ClientDialogue(_storage);

                    if (_storage.Orders[currentOrderId].FullPrice == default)
                        _storage.Orders.RemoveAt(currentOrderId);

                    Console.Clear();
                    continue;
                }

                if (choice == 0)
                    break;

                Console.WriteLine("Enter a correct number.");
            }

            return new Storage {PcPeripherals = _storage.PcPeripherals, Orders = _storage.Orders, PcParts = _storage.PcParts};
        }
    }
}
