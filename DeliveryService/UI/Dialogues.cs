using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryService.Interfaces;
using DeliveryService.Models;

namespace DeliveryService.UI
{
    public class Dialogues : IDialogue
    {
        public IStorable BusinessDialogue(IStorable storage)
        {
            var itemsController = new ItemsController();
            var presenter = new Presenter();

            while (true)
            {
                Console.WriteLine("1 - Add PC part\n" +
                                  "2 - Add PC peripheral\n" +
                                  "3 - Show added PC parts\n" +
                                  "4 - Show added PC peripherals\n" +
                                  "5 - Show active orders\n" +
                                  "0 - Main menu");
                var input = Console.ReadLine();

                if (input == string.Empty || !int.TryParse(input, out var choice))
                {
                    Console.Clear();
                    Console.WriteLine("Enter a number!");
                    continue;
                }

                if (choice == 1)
                    storage.PcParts.Add(itemsController.CreatePcPart(storage.PcParts.Count));

                else if (choice == 2)
                    storage.PcPeripherals.Add(itemsController.CreatePcPeripheral(storage.PcPeripherals.Count));

                else if (choice == 3)
                {
                    Console.Clear();
                    Console.WriteLine(presenter.ShowPcParts(storage.PcParts.ToList()));
                }

                else if (choice == 4)
                {
                    Console.Clear();
                    Console.WriteLine(presenter.ShowPcPeripherals(storage.PcPeripherals));
                }

                else if (choice == 5)
                {
                    Console.Clear();
                    Console.WriteLine(presenter.ShowActiveOrders(storage.Orders));
                }

                else if (choice == 0)
                    break;
            }

            return storage;
        }

        public (IStorable, int) ClientDialogue(IStorable storage)
        {
            var itemsController = new ItemsController();
            var presenter = new Presenter();

            var currentOrder = new Order {Id = storage.Orders.Count};
            storage.Orders.Add(currentOrder);

            while (true)
            {
                Console.WriteLine("1 - Show available PC parts\n" +
                                  "2 - Show available PC peripherals\n" +
                                  "3 - Show your order\n" +
                                  "0 - Main menu");
                var input = Console.ReadLine();

                if (input == string.Empty || !int.TryParse(input, out var choice))
                {
                    Console.Clear();
                    Console.WriteLine("Enter a number!");
                    continue;
                }

                if (choice == 1)
                {
                    Console.Clear();
                    Console.WriteLine(presenter.ShowPcParts(storage.PcParts));
                    itemsController.AddPcPartsToOrder(storage, currentOrder.Id);
                    Console.Clear();
                }

                else if (choice == 2)
                {
                    Console.Clear();
                    Console.WriteLine(presenter.ShowPcPeripherals(storage.PcPeripherals));
                    itemsController.AddPcPeripheralsToOrder(storage, currentOrder.Id);
                    Console.Clear();
                }

                else if (choice == 3)
                {
                    storage.Orders.Last().RecalculatePrice();
                    Console.Clear();
                    Console.WriteLine(presenter.ShowOrder(storage.Orders.Last()));
                }

                else if (choice == 0)
                    break;
            }

            return (storage, currentOrder.Id);
        }
    }
}
