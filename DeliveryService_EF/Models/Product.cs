namespace DeliveryService_EF.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int AmountInStock { get; set; }
        public Category CategoryId { get; set; }
        public Supplier SupplierId { set; get; }
    }
}
