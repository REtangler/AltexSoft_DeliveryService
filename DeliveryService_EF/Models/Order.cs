using System;
using System.Collections.Generic;
using DeliveryService_EF.Enums;

namespace DeliveryService_EF.Models
{
    public class Order
    {
        public int Id { get; set; }
        public IList<Product> Product { get; set; }
        public Client Client { get; set; }
        public Deliveryman Deliveryman { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveredDate { get; set; }
        public DeliveryTariff DeliveryPrice { get; set; }
        public decimal FullPrice { get; set; }
        public string DeliveryAddress { get; set; }
        public OrderStatus Status { get; set; }
    }
}
