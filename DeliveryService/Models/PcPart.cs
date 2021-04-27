using DeliveryService.Interfaces;

namespace DeliveryService.Models
{
    public class PcPart : IProduceable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public decimal Price { get; set; }

        public string Manufacturer { get; set; }
        public int Amount { get; set; }

        public void CreateProduct(int id, string name, decimal price, string manufacturer, string category, int amount)
        {
            Id = id;
            Name = name;
            Category = category;
            Price = price;
            Manufacturer = manufacturer;
            Amount = amount;
        }
    }
}
