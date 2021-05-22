using System;
using DeliveryService.Interfaces;
using DeliveryService.Logic;
using DeliveryService.Models;

namespace DeliveryService.UI
{
    public class Presenter : IPresentable, IMenuPresentable, IDialogue
    {
        private readonly RegExpression _regExpression;
        private readonly Controller _controller;

        public Presenter(Controller controller, RegExpression regExp, ILogger logger)
        {
            _regExpression = regExp;
            _controller = controller;
        }

        public void Start()
        {
            while (true)
            {
                var choice = ShowMainMenu();

                if (choice == 1)
                {
                    Console.Clear();

                    StartBusinessDialogue();

                    Console.Clear();
                    continue;
                }

                if (choice == 2)
                {
                    Console.Clear();

                    var currentOrderId = StartClientDialogue();

                    _controller.DeleteEmptyOrder(currentOrderId);

                    Console.Clear();
                    continue;
                }

                if (choice == 0)
                    break;
            }
        }

        public void StartBusinessDialogue()
        {
            while (true)
            {
                var choice = ShowBusinessMenu();

                if (choice == 1)
                {
                    var product = GetPcPartInfo();
                    _controller.AddPcPartToDb(product);
                    _logger.Log($"PC part \"{product.Name}\" x{product.Amount} was added to marketplace");
                }
                
                else if (choice == 2)
                {
                    var product = GetPcPeripheralInfo();
                    _controller.AddPcPeripheralToDb(product);
                    _logger.Log($"PC peripheral \"{product.Name}\" x{product.Amount} was added to marketplace");
                }

                else if (choice == 3)
                {
                    Console.Clear();
                    ShowPcParts();
                }

                else if (choice == 4)
                {
                    Console.Clear();
                    ShowPcPeripherals();
                }

                else if (choice == 5)
                {
                    Console.Clear();
                    ShowOrders();
                }

                else if (choice == 0)
                    break;
            }
        }

        public int StartClientDialogue()
        {
            var currentOrder = _controller.CreateOrder(GetClientPhoneNumber(), GetClientAddress());

            while (true)
            {
                var choice = ShowClientMenu();

                if (choice == 1)
                {
                    while (true)
                    {
                        int? itemId = AddPcPartsToOrder();
                        if (itemId is null)
                            break;

                        _controller.AddPcPartToOrder(currentOrder.Id, (int)itemId);
                        _logger.Log($"PC part #{(int)itemId} was added to order #{currentOrder.Id}");
                    }
                    Console.Clear();
                }

                else if (choice == 2)
                {
                    while (true)
                    {
                        int? itemId = AddPcPeripheralsToOrder();
                        if (itemId is null)
                            break;

                        _controller.AddPcPeripheralToOrder(currentOrder.Id, (int)itemId);
                        _logger.Log($"PC peripheral #{(int)itemId} was added to order #{currentOrder.Id}");
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

            return currentOrder.Id;
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

        public void ShowOrders()
        {
            var orders = _controller.GetOrders();
            if (orders.Count is 0)
                Console.WriteLine("There are no orders!");
            
            foreach (var order in orders)
            {
                Console.WriteLine($"Order Id #{order.Id}\n" +
                          $"Address: {order.Address}\n" +
                          $"Phone Number: {order.PhoneNumber}\n" +
                          $"Full price: {order.FullPrice}\n\n");
            }
        }

        public void ShowPcPeripherals()
        {
            var pcPeripherals = _controller.GetPcPeripherals();
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

        public void ShowPcParts()
        {
            var pcParts = _controller.GetPcParts();
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
        public int? AddPcPartsToOrder()
        {
            int choice;

            while (true)
            {
                Console.Clear();
                ShowPcParts();
                Console.WriteLine("Enter product Id to add it to your order.\n" +
                                  "Enter empty line to stop ordering PC parts.");

                var input = Console.ReadLine();
                if (input == string.Empty)
                    return null;

                if (!int.TryParse(input, out choice))
                    continue;

                if (_controller.CanAddPcPartsToOrder(choice))
                    break;
                
                Console.WriteLine("Enter correct Id or empty line to stop ordering PC parts!");
            }

            return choice;
        }

        public int? AddPcPeripheralsToOrder()
        {
            int choice;

            while (true)
            {
                Console.Clear();
                ShowPcPeripherals();
                Console.WriteLine("Enter product Id to add it to your order.\n" +
                                  "Enter empty line to stop ordering PC peripherals.");

                var input = Console.ReadLine();
                if (input == string.Empty)
                    return null;

                if (!int.TryParse(input, out choice))
                    continue;

                if (_controller.CanAddPcPeripheralsToOrder(choice))
                    break;

                Console.WriteLine("Enter correct Id or empty line to stop ordering PC peripherals!");
            }

            return choice;
        }

        public PcPeripheral GetPcPeripheralInfo()
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
            pcPeripheral.CreateProduct(default, name, price, manufacturer, category, amount);

            return pcPeripheral;
        }

        public PcPart GetPcPartInfo()
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
            pcPart.CreateProduct(default, name, price, manufacturer, category, amount);
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

        private static void ShowOrder(IOrder order)
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
    }
}
