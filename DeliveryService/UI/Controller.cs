using System;
using System.Collections.Generic;
using System.Linq;
using DeliveryService.Models;
using DeliveryService.Data;
using DeliveryService.Interfaces;

namespace DeliveryService.UI
{
    class Controller : IControllable
    {
        private static List<PcPart> _pcParts;
        private static List<PcPeripheral> _pcPeripherals;
        private static List<Order> _orders;

        public Storage Start(Storage storage)
        {
            _pcParts = storage.PcParts.ToList();
            _pcPeripherals = storage.PcPeripherals.ToList();
            _orders = storage.Orders.ToList();

            var presenter = new Presenter();

            while (true)
            {
                Console.WriteLine("1 - Business\n" +
                                  "2 - Client\n" +
                                  "0 - Exit");
                var input = Console.ReadLine();

                if (input == string.Empty)
                {
                    Console.WriteLine("Enter a number!");
                    continue;
                }

                var choice = int.Parse(input);

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

                        if (input == string.Empty)
                        {
                            Console.WriteLine("Enter a number!");
                            continue;
                        }

                        choice = int.Parse(input);

                        if (choice == 1)
                            _pcParts.Add(CreatePcPart());

                        else if (choice == 2)
                            _pcPeripherals.Add(CreatePcPeripheral());

                        else if (choice == 3)
                            Console.WriteLine(presenter.ShowPcParts(_pcParts));

                        else if (choice == 4)
                            Console.WriteLine(presenter.ShowPcPeripherals(_pcPeripherals));

                        else if (choice == 5)
                        {
                            Console.Clear();
                            Console.WriteLine(presenter.ShowActiveOrders(_orders));
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

                    var currentOrder = new Order {Id = _orders.Count};
                    _orders.Add(currentOrder);

                    while (true)
                    {
                        Console.WriteLine("1 - Show available PC parts\n" +
                                          "2 - Show available PC peripherals\n" +
                                          "3 - Show your order\n" +
                                          "0 - Main menu");
                        input = Console.ReadLine();

                        if (input == string.Empty)
                        {
                            Console.Clear();
                            Console.WriteLine("Enter a number!");
                            continue;
                        }

                        choice = int.Parse(input);

                        if (choice == 1)
                        {
                            Console.Clear();
                            Console.WriteLine(presenter.ShowPcParts(_pcParts));
                            AddPcPartsToOrder(currentOrder);
                        }

                        else if (choice == 2)
                        {
                            Console.Clear();
                            Console.WriteLine(presenter.ShowPcPeripherals(_pcPeripherals));
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
                        _orders.RemoveAt(currentOrder.Id);

                    Console.Clear();
                    continue;
                }

                if (choice == 0)
                    break;

                Console.WriteLine("Enter a correct number.");
            }

            return new Storage {PcPeripherals = _pcPeripherals, Orders = _orders, PcParts = _pcParts};
        }

        private static PcPeripheral CreatePcPeripheral()
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
            pcPeripheral.CreateProduct(_pcPeripherals.Count, name, price, manufacturer, category, amount);
            return pcPeripheral;
        }

        private static PcPart CreatePcPart()
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
            pcPart.CreateProduct(_pcParts.Count, name, price, manufacturer, category, amount);
            return pcPart;
        }

        private static void AddPcPartsToOrder(Order order)
        {
            Console.WriteLine("Enter product Id to add it to your order.\n" +
                              "Enter empty line to stop ordering PC parts.");

            var presenter = new Presenter();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == string.Empty)
                    break;

                if (int.TryParse(input, out var choice) && choice < _pcParts.Count)
                {
                    if (_pcParts[choice].Amount <= 0)
                    {
                        Console.WriteLine("Item is out of stock!");
                        continue;
                    }
                    _orders[order.Id].PcParts.Add(_pcParts[choice]);
                    _pcParts[choice].Amount--;
                    Console.Clear();
                    Console.WriteLine(presenter.ShowPcParts(_pcParts));
                    Console.WriteLine($"{_pcParts[choice].Name} was added to your order.");
                    Console.WriteLine("Enter product Id to add it to your order.\n" +
                                      "Enter empty line to stop ordering PC parts.");
                }
                else
                    Console.WriteLine("Enter correct Id or empty line to stop ordering PC parts!");
            }
            Console.Clear();
        }

        private static void AddPcPeripheralsToOrder(Order order)
        {
            Console.WriteLine("Enter product Id to add it to your order.\n" +
                              "Enter empty line to stop ordering PC peripherals.");

            var presenter = new Presenter();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == string.Empty)
                    break;

                if (int.TryParse(input, out var choice) && choice < _pcPeripherals.Count)
                {
                    if (_pcPeripherals[choice].Amount <= 0)
                    {
                        Console.WriteLine("Item is out of stock!");
                        continue;
                    }
                    _orders[order.Id].PcPeripherals.Add(_pcPeripherals[choice]);
                    _pcPeripherals[choice].Amount--;
                    Console.Clear();
                    Console.WriteLine(presenter.ShowPcPeripherals(_pcPeripherals));
                    Console.WriteLine($"{_pcPeripherals[choice].Name} was added to your order.");
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
