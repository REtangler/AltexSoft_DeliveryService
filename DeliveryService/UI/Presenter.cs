using System;
using System.Collections.Generic;
using System.Linq;
using DeliveryService.Interfaces;
using DeliveryService.Logic;
using DeliveryService.Models;

namespace DeliveryService.UI
{
    public class Presenter : IPresentable, IMenuPresentable, IItemPresentable, IDialogue
    {
        private readonly RegExpression _regExpression;

        public Presenter()
        {
            _regExpression = new RegExpression();
        }

        public IStorable BusinessDialogue(IStorable storage)
        {
            while (true)
            {
                var choice = ShowBusinessMenu();

                if (choice == 1)
                    storage.PcParts.Add(GetPcPartInfo(storage.PcParts.Count));

                else if (choice == 2)
                    storage.PcPeripherals.Add(GetPcPeripheralInfo(storage.PcPeripherals.Count));

                else if (choice == 3)
                {
                    Console.Clear();
                    ShowPcParts(storage.PcParts.ToList());
                }

                else if (choice == 4)
                {
                    Console.Clear();
                    ShowPcPeripherals(storage.PcPeripherals);
                }

                else if (choice == 5)
                {
                    Console.Clear();
                    ShowActiveOrders(storage.Orders);
                }

                else if (choice == 0)
                    break;
            }

            return storage;
        }

        public (IStorable, int) ClientDialogue(IStorable storage)
        {
            var currentOrder = new Order
            {
                Id = storage.Orders.Count,
                PhoneNumber = GetClientPhoneNumber(),
                Address = GetClientAddress()
            };

            while (true)
            {
                var choice = ShowClientMenu();

                if (choice == 1)
                {
                    while (true)
                    {
                        int? itemId = AddPcPartsToOrder(storage);
                        if (itemId is null)
                            break;
                        currentOrder.PcParts.Add(storage.PcParts[(int)itemId]);
                        storage.PcParts[(int)itemId].Amount--;
                    }
                    Console.Clear();
                }

                else if (choice == 2)
                {
                    while (true)
                    {
                        int? itemId = AddPcPeripheralsToOrder(storage);
                        if (itemId is null)
                            break;
                        currentOrder.PcPeripherals.Add(storage.PcPeripherals[(int)itemId]);
                        storage.PcPeripherals[(int)itemId].Amount--;
                    }
                    Console.Clear();
                }

                else if (choice == 3)
                {
                    ShowOrder(currentOrder);
                }

                else if (choice == 0)
                    break;
            }

            storage.Orders.Add(currentOrder);

            return (storage, currentOrder.Id);
        }

        public string GetClientPhoneNumber()
        {
            while (true)
            {
                Console.WriteLine("Enter your phone number: ");
                var input = Console.ReadLine();

                if (input != string.Empty && _regExpression.CheckNumber(input))
                {
                    Console.Clear();
                    return input;
                }

                Console.Clear();
            }
        }

        public string GetClientAddress()
        {
            while (true)
            {
                Console.WriteLine("Enter your address: ");
                var input = Console.ReadLine();

                if (input != string.Empty && _regExpression.CheckAddress(input))
                {
                    Console.Clear();
                    return input;
                }

                Console.Clear();
            }
        }
        public int? AddPcPartsToOrder(IStorable storage)
        {
            int choice;

            while (true)
            {
                Console.Clear();
                ShowPcParts(storage.PcParts);
                Console.WriteLine("Enter product Id to add it to your order.\n" +
                                  "Enter empty line to stop ordering PC parts.");

                var input = Console.ReadLine();
                if (input == string.Empty)
                    return null;

                if (int.TryParse(input, out choice) && choice < storage.PcParts.Count)
                {
                    if (storage.PcParts[choice].Amount <= 0)
                    {
                        Console.WriteLine("Item is out of stock!");
                        continue;
                    }
                    break;
                }
                Console.WriteLine("Enter correct Id or empty line to stop ordering PC parts!");
            }

            return choice;
        }

        public int? AddPcPeripheralsToOrder(IStorable storage)
        {
            int choice;

            while (true)
            {
                Console.Clear();
                ShowPcPeripherals(storage.PcPeripherals);
                Console.WriteLine("Enter product Id to add it to your order.\n" +
                                  "Enter empty line to stop ordering PC peripherals.");

                var input = Console.ReadLine();
                if (input == string.Empty)
                    return null;

                if (int.TryParse(input, out choice) && choice < storage.PcPeripherals.Count)
                {
                    if (storage.PcPeripherals[choice].Amount <= 0)
                    {
                        Console.WriteLine("Item is out of stock!");
                        continue;
                    }
                    break;
                }
                Console.WriteLine("Enter correct Id or empty line to stop ordering PC peripherals!");
            }

            return choice;
        }

        public PcPeripheral GetPcPeripheralInfo(int id)
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
            pcPeripheral.CreateProduct(id, name, price, manufacturer, category, amount);

            return pcPeripheral;
        }

        public PcPart GetPcPartInfo(int id)
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
            pcPart.CreateProduct(id, name, price, manufacturer, category, amount);
            return pcPart;
        }

        public int ShowBusinessMenu()
        {
            int choice;

            while (true)
            {
                Console.WriteLine("1 - Add PC part\n" +
                                  "2 - Add PC peripheral\n" +
                                  "3 - Show added PC parts\n" +
                                  "4 - Show added PC peripherals\n" +
                                  "5 - Show active orders\n" +
                                  "0 - Main menu");
                var input = Console.ReadLine();

                if (input == string.Empty || !int.TryParse(input, out choice))
                {
                    Console.Clear();
                    Console.WriteLine("Enter a number!");
                    continue;
                }

                break;
            }

            return choice;
        }

        public int ShowClientMenu()
        {
            int choice;
            while (true)
            {
                Console.WriteLine("1 - Show available PC parts\n" +
                                  "2 - Show available PC peripherals\n" +
                                  "3 - Show your order\n" +
                                  "0 - Main menu");
                var input = Console.ReadLine();

                if (input == string.Empty || !int.TryParse(input, out choice))
                {
                    Console.Clear();
                    Console.WriteLine("Enter a number!");
                    continue;
                }

                break;
            }

            return choice;
        }

        public int ShowMainMenu()
        {
            int choice;
            while (true)
            {
                Console.WriteLine("1 - Business\n" +
                                  "2 - Client\n" +
                                  "0 - Exit");
                var input = Console.ReadLine();

                if (input == string.Empty || !int.TryParse(input, out choice))
                {
                    Console.Clear();
                    Console.WriteLine("Enter a number!");
                    continue;
                }

                break;
            }

            return choice;
        }

        public void ShowActiveOrders(IList<Order> orders)
        {
            if (orders.Count is 0)
            {
                Console.WriteLine("There are no active orders!");
                return;
            }

            foreach (var order in orders)
            {
                Console.WriteLine($"Order Id #{order.Id}\n" +
                          $"Address: {order.Address}\n" +
                          $"Phone Number: {order.PhoneNumber}\n" +
                          $"Full price: {order.FullPrice}\n\n");
            }
        }

        public void ShowOrder(Order order)
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

            Console.WriteLine($"Address: {order.Address}\n");
            Console.WriteLine($"Phone Number: {order.PhoneNumber}\n");
            Console.WriteLine($"Total price: {order.FullPrice}");
        }

        public void ShowPcPeripherals(IList<PcPeripheral> pcPeripherals)
        {
            Console.Clear();
            foreach (var pcPeripheral in pcPeripherals)
            {
                Console.WriteLine($"Id: {pcPeripheral.Id}\n" +
                          $"Name: {pcPeripheral.Name}\n" +
                          $"Category: {pcPeripheral.Category}\n" +
                          $"Price: {pcPeripheral.Price}\n" +
                          $"Manufacturer: {pcPeripheral.Manufacturer}\n" +
                          $"Amount: {pcPeripheral.Amount}\n");
            }
            Console.WriteLine("----------END OF LIST----------\n");
        }

        public void ShowPcParts(IList<PcPart> pcParts)
        {
            foreach (var pcPart in pcParts)
            {
                Console.WriteLine($"Id: {pcPart.Id}\n" +
                          $"Name: {pcPart.Name}\n" +
                          $"Category: {pcPart.Category}\n" +
                          $"Price: {pcPart.Price}\n" +
                          $"Manufacturer: {pcPart.Manufacturer}\n" +
                          $"Amount: {pcPart.Amount}\n");
            }
            Console.WriteLine("----------END OF LIST----------\n");
        }
    }
}
