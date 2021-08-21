namespace AltexFood_Delivery.DAL.DTOs
{
    [Dapper.Contrib.Extensions.Table("Products")]
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int AmountInStock { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
        public string Type { get; set; }
    }
}
