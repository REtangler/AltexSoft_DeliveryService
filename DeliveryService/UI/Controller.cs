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
        private readonly IStorable _storage;

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

                if (choice == 1)    // Business entry point
                {
                    Console.Clear();
                    while (true)
                    {
                        Console.WriteLine("1 - Add PC part\n" +
                                          "2 - Add PC peripheral\n" +
                                          "3 - Show added PC parts\n" +
                                          "4 - Show added PC peripherals\n" +
                                          "5 - Show active orders\n" +
                                          "0 - Main menu");
                        input = Console.ReadLine();

                        if (input == string.Empty || !int.TryParse(input, out choice))
                        {
                            Console.Clear();
                            Console.WriteLine("Enter a number!");
                            continue;
                        }

                        if (choice == 1)
                            _storage.PcParts.Add(CreatePcPart());

                        else if (choice == 2)
                            _storage.PcPeripherals.Add(CreatePcPeripheral());

                        else if (choice == 3)
                            Console.WriteLine(presenter.ShowPcParts(_storage.PcParts.ToList()));

                        else if (choice == 4)
                            Console.WriteLine(presenter.ShowPcPeripherals(_storage.PcPeripherals));

                        else if (choice == 5)
                        {
                            Console.Clear();
                            Console.WriteLine(presenter.ShowActiveOrders(_storage.Orders));
                        }

                        else if (choice == 0)
                            break;
                    }

                    Console.Clear();
                    continue;
                }

                if (choice == 2)    // Client entry point
                {
                    Console.Clear();

                    var currentOrder = new Order {Id = _storage.Orders.Count};
                    _storage.Orders.Add(currentOrder);

                    while (true)
                    {
                        Console.WriteLine("1 - Show available PC parts\n" +
                                          "2 - Show available PC peripherals\n" +
                                          "3 - Show your order\n" +
                                          "0 - Main menu");
                        input = Console.ReadLine();

                        if (input == string.Empty || !int.TryParse(input, out choice))
                        {
                            Console.Clear();
                            Console.WriteLine("Enter a number!");
                            continue;
                        }

                        if (choice == 1)
                        {
                            Console.Clear();
                            Console.WriteLine(presenter.ShowPcParts(_storage.PcParts));
                            AddPcPartsToOrder(currentOrder);
                        }

                        else if (choice == 2)
                        {
                            Console.Clear();
                            Console.WriteLine(presenter.ShowPcPeripherals(_storage.PcPeripherals));
                            AddPcPeripheralsToOrder(currentOrder);
                        }

                        else if (choice == 3)
                        {
                            currentOrder.RecalculatePrice();
                            Console.Clear();
                            Console.WriteLine(presenter.ShowOrder(currentOrder));
                        }

                        else if (choice == 0)
                            break;
                    }

                    if (currentOrder.FullPrice == default)
                        _storage.Orders.RemoveAt(currentOrder.Id);

                    Console.Clear();
                    continue;
                }

                if (choice == 0)
                    break;

                Console.WriteLine("Enter a correct number.");
            }

            return new Storage {PcPeripherals = _storage.PcPeripherals, Orders = _storage.Orders, PcParts = _storage.PcParts};
        }

        private PcPeripheral CreatePcPeripheral()
        {
            Console.Clear();
            Console.Write("Enter a name for the peripheral: ");
            var name = Console.ReadLine();

            Console.Write("Enter a category: ");
            var category = Console.ReadLine();

            decimal price;
            while (true)
            {
                Console.Write($"Enter a price for {name}: ");
                var priceInput = Console.ReadLine();
                if (decimal.TryParse(priceInput, out price))
                    break;
                Console.WriteLine("Incorrect input!");
            }

            Console.Write($"Enter a manufacturer for {name}: ");
            var manufacturer = Console.ReadLine();

            int amount;
            while (true)
            {
                Console.Write($"Enter amount of items for {name}: ");
                var amountInput = Console.ReadLine();
                if (int.TryParse(amountInput, out amount))
                    break;
                Console.WriteLine("Incorrect input!");
            }
            Console.Clear();

            var pcPeripheral = new PcPeripheral();
            pcPeripheral.CreateProduct(_storage.PcPeripherals.Count, name, price, manufacturer, category, amount);
            return pcPeripheral;
        }

        private PcPart CreatePcPart()
        {
            Console.Clear();
            Console.Write("Enter a name for the part: ");
            var name = Console.ReadLine();

            Console.Write("Enter a category: ");
            var category = Console.ReadLine();

            decimal price;
            while (true)
            {
                Console.Write($"Enter a price for {name}: ");
                var priceInput = Console.ReadLine();
                if (decimal.TryParse(priceInput, out price))
                    break;
                Console.WriteLine("Incorrect input!");
            }

            Console.Write($"Enter a manufacturer for {name}: ");
            var manufacturer = Console.ReadLine();

            int amount;
            while (true)
            {
                Console.Write($"Enter amount of items for {name}: ");
                var amountInput = Console.ReadLine();
                if (int.TryParse(amountInput, out amount))
                    break;
                Console.WriteLine("Incorrect input!");
            }
            Console.Clear();

            var pcPart = new PcPart();
            pcPart.CreateProduct(_storage.PcParts.Count, name, price, manufacturer, category, amount);
            return pcPart;
        }

        private void AddPcPartsToOrder(Order order)
        {
            Console.WriteLine("Enter product Id to add it to your order.\n" +
                              "Enter empty line to stop ordering PC parts.");

            var presenter = new Presenter();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == string.Empty)
                    break;

                if (int.TryParse(input, out var choice) && choice < _storage.PcParts.Count)
                {
                    if (_storage.PcParts[choice].Amount <= 0)
                    {
                        Console.WriteLine("Item is out of stock!");
                        continue;
                    }
                    _storage.Orders[order.Id].PcParts.Add(_storage.PcParts[choice]);
                    _storage.PcParts[choice].Amount--;
                    Console.Clear();
                    Console.WriteLine(presenter.ShowPcParts(_storage.PcParts));
                    Console.WriteLine($"{_storage.PcParts[choice].Name} was added to your order.");
                    Console.WriteLine("Enter product Id to add it to your order.\n" +
                                      "Enter empty line to stop ordering PC parts.");
                }
                else
                    Console.WriteLine("Enter correct Id or empty line to stop ordering PC parts!");
            }
            Console.Clear();
        }

        private void AddPcPeripheralsToOrder(Order order)
        {
            Console.WriteLine("Enter product Id to add it to your order.\n" +
                              "Enter empty line to stop ordering PC peripherals.");

            var presenter = new Presenter();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == string.Empty)
                    break;

                if (int.TryParse(input, out var choice) && choice < _storage.PcPeripherals.Count)
                {
                    if (_storage.PcPeripherals[choice].Amount <= 0)
                    {
                        Console.WriteLine("Item is out of stock!");
                        continue;
                    }
                    _storage.Orders[order.Id].PcPeripherals.Add(_storage.PcPeripherals[choice]);
                    _storage.PcPeripherals[choice].Amount--;
                    Console.Clear();
                    Console.WriteLine(presenter.ShowPcPeripherals(_storage.PcPeripherals));
                    Console.WriteLine($"{_storage.PcPeripherals[choice].Name} was added to your order.");
                    Console.WriteLine("Enter product Id to add it to your order.\n" +
                                      "Enter empty line to stop ordering PC peripherals.");
                }
                else
                    Console.WriteLine("Enter correct Id or empty line to stop ordering PC peripherals!");
            }
            Console.Clear();
        }
    }
}
