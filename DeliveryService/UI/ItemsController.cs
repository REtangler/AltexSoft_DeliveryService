using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryService.Interfaces;
using DeliveryService.Models;

namespace DeliveryService.UI
{
    public class ItemsController : IItemsController
    {
        public PcPeripheral CreatePcPeripheral(int id)
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

        public PcPart CreatePcPart(int id)
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

        public IStorable AddPcPartsToOrder(IStorable storage, int id)
        {
            Console.WriteLine("Enter product Id to add it to your order.\n" +
                              "Enter empty line to stop ordering PC parts.");

            var presenter = new Presenter();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == string.Empty)
                    break;

                if (int.TryParse(input, out var choice) && choice < storage.PcParts.Count)
                {
                    if (storage.PcParts[choice].Amount <= 0)
                    {
                        Console.WriteLine("Item is out of stock!");
                        continue;
                    }
                    storage.Orders[id].PcParts.Add(storage.PcParts[choice]);
                    storage.PcParts[choice].Amount--;
                    Console.Clear();
                    Console.WriteLine(presenter.ShowPcParts(storage.PcParts));
                    Console.WriteLine($"{storage.PcParts[choice].Name} was added to your order.");
                    Console.WriteLine("Enter product Id to add it to your order.\n" +
                                      "Enter empty line to stop ordering PC parts.");
                }
                else
                    Console.WriteLine("Enter correct Id or empty line to stop ordering PC parts!");
            }
            
            return storage;
        }

        public IStorable AddPcPeripheralsToOrder(IStorable storage, int id)
        {
            Console.WriteLine("Enter product Id to add it to your order.\n" +
                              "Enter empty line to stop ordering PC peripherals.");

            var presenter = new Presenter();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == string.Empty)
                    break;

                if (int.TryParse(input, out var choice) && choice < storage.PcPeripherals.Count)
                {
                    if (storage.PcPeripherals[choice].Amount <= 0)
                    {
                        Console.WriteLine("Item is out of stock!");
                        continue;
                    }
                    storage.Orders[id].PcPeripherals.Add(storage.PcPeripherals[choice]);
                    storage.PcPeripherals[choice].Amount--;
                    Console.Clear();
                    Console.WriteLine(presenter.ShowPcPeripherals(storage.PcPeripherals));
                    Console.WriteLine($"{storage.PcPeripherals[choice].Name} was added to your order.");
                    Console.WriteLine("Enter product Id to add it to your order.\n" +
                                      "Enter empty line to stop ordering PC peripherals.");
                }
                else
                    Console.WriteLine("Enter correct Id or empty line to stop ordering PC peripherals!");
            }

            return storage;
        }
    }
}
