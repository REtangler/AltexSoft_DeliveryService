using System;
using System.Collections.Generic;

namespace DeliveryService
{
    class Program
    {
        private static List<PcPart> _pcParts;
        private static List<PcPeripheral> _pcPeripherals;
        private static List<Order> _orders;

        static void Main(string[] args)
        {
            _pcParts = new List<PcPart>();
            _pcPeripherals = new List<PcPeripheral>();
            _orders = new List<Order>();

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
                            ShowPcParts();

                        else if (choice == 4)
                            ShowPcPeripherals();

                        else if (choice == 5)
                            ShowActiveOrders();

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
                            ShowPcParts();
                            AddPcPartsToOrder(currentOrder);
                        }

                        else if (choice == 2)
                        {
                            ShowPcPeripherals();
                            AddPcPeripheralsToOrder(currentOrder);
                        }

                        else if (choice == 3)
                        {
                            RecalculatePrice(currentOrder);
                            ShowOrder(currentOrder);
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
        }

        private static void ShowActiveOrders()
        {
            Console.Clear();

            if (_orders.Count is 0)
            {
                Console.WriteLine("There are no active orders!");
                return;
            }

            foreach (var order in _orders)
            {
                Console.WriteLine($"Order Id #{order.Id}\n" +
                                  $"Full price: {order.FullPrice}\n");
            }
        }

        private static void RecalculatePrice(Order order)
        {
            if (order.PcParts.Count is 0 && order.PcPeripherals.Count is 0)
            {
                order.FullPrice = default;
                return;
            }

            foreach (var pcPart in order.PcParts)
            {
                order.FullPrice += pcPart.Price;
            }

            foreach (var pcPeripheral in order.PcPeripherals)
            {
                order.FullPrice += pcPeripheral.Price;
            }
        }

        private static void ShowOrder(Order order)
        {
            Console.Clear();
            if (order.FullPrice == default)
            {
                Console.WriteLine("Your order is empty!");
                return;
            }

            Console.WriteLine($"Order Id: {order.Id}\n");

            if (order.PcParts.Count > 0)
            {
                for (int i = 0; i < order.PcParts.Count; i++)
                {
                    var pcPart = order.PcParts[i];
                    Console.WriteLine($"PC part #{i + 1}\n" +
                                      $"Id: {pcPart.Id}\n" +
                                      $"Name: {pcPart.Name}\n" +
                                      $"Category: {pcPart.Category}\n" +
                                      $"Price: {pcPart.Price}\n" +
                                      $"Manufacturer: {pcPart.Manufacturer}\n");
                }

                Console.WriteLine("----------END OF PC PARTS LIST----------\n");
            }

            if (order.PcPeripherals.Count > 0)
            {
                for (int i = 0; i < order.PcPeripherals.Count; i++)
                {
                    var pcPeripheral = order.PcPeripherals[i];
                    Console.WriteLine($"PC peripheral #{i + 1}\n" +
                                      $"Id: {pcPeripheral.Id}\n" +
                                      $"Name: {pcPeripheral.Name}\n" +
                                      $"Category: {pcPeripheral.Category}\n" +
                                      $"Price: {pcPeripheral.Price}\n" +
                                      $"Manufacturer: {pcPeripheral.Manufacturer}\n");
                }
                Console.WriteLine("----------END OF PC PERIPHERALS LIST----------\n");
            }

            Console.WriteLine($"Total price: {order.FullPrice}");
        }

        private static void ShowPcPeripherals()
        {
            Console.Clear();
            foreach (var pcPeripheral in _pcPeripherals)
            {
                Console.WriteLine($"Id: {pcPeripheral.Id}\n" +
                                  $"Name: {pcPeripheral.Name}\n" +
                                  $"Category: {pcPeripheral.Category}\n" +
                                  $"Price: {pcPeripheral.Price}\n" +
                                  $"Manufacturer: {pcPeripheral.Manufacturer}\n");
            }
            Console.WriteLine("----------END OF LIST----------\n");
        }

        private static void ShowPcParts()
        {
            Console.Clear();
            foreach (var pcPart in _pcParts)
            {
                Console.WriteLine($"Id: {pcPart.Id}\n" +
                                  $"Name: {pcPart.Name}\n" +
                                  $"Category: {pcPart.Category}\n" +
                                  $"Price: {pcPart.Price}\n" +
                                  $"Manufacturer: {pcPart.Manufacturer}\n");
            }
            Console.WriteLine("----------END OF LIST----------\n");
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

            Console.Clear();

            var pcPeripheral = new PcPeripheral();
            pcPeripheral.CreateProduct(_pcPeripherals.Count, name, price, manufacturer, category);
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

            Console.Clear();

            var pcPart = new PcPart();
            pcPart.CreateProduct(_pcParts.Count, name, price, manufacturer, category);
            return pcPart;
        }

        private static void AddPcPartsToOrder(Order order)
        {
            Console.WriteLine("Enter product Id to add it to your order.\n" +
                              "Enter empty line to stop ordering PC parts.");
            while (true)
            {
                var input = Console.ReadLine();
                if (input == string.Empty)
                    break;

                if (int.TryParse(input, out var choice) && choice < _pcParts.Count)
                {
                    _orders[order.Id].PcParts.Add(_pcParts[choice]);
                    Console.Clear();
                    ShowPcParts();
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
            while (true)
            {
                var input = Console.ReadLine();
                if (input == string.Empty)
                    break;

                if (int.TryParse(input, out var choice) && choice < _pcPeripherals.Count)
                {
                    _orders[order.Id].PcPeripherals.Add(_pcPeripherals[choice]);
                    Console.Clear();
                    ShowPcPeripherals();
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
