using DeliveryService_EF.Enums;

namespace DeliveryService_EF.Models
{
    public class DeliveryTariffs
    {
        public int Id { get; set; }
        public ParcelWeight ParcelWeight { get; set; }
        public ParcelDimensions ParcelDimensions { get; set; }
        public decimal DeliveryPrice { get; set; }
    }
}
