using AltexFood_Delivery.DAL.Enums;

namespace AltexFood_Delivery.DAL.Models
{
    public class DeliveryTariff
    {
        public int Id { get; set; }
        public ParcelWeight ParcelWeight { get; set; }
        public ParcelDimensions ParcelDimensions { get; set; }
        public decimal DeliveryPrice { get; set; }
    }
}
