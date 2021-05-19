namespace DeliveryService.Interfaces
{
    public interface IProduceable
    {
        int Id { get; set; }

        string Name { get; set; }

        string Category { get; set; }

        decimal Price { get; set; }

        string Manufacturer { get; set; }

        int Amount { get; set; }

        void CreateProduct(int id, string name, decimal price, string manufacturer, string category, int amount);
    }
}
