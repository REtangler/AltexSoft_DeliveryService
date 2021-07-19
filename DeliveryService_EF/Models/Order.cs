using System;
using System.Collections.Generic;
using DeliveryService_EF.Enums;

namespace DeliveryService_EF.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public IList<Products> ProductId { get; set; }
        public Client ClientId { get; set; }
        public Deliveryman DeliverymanId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveredDate { get; set; }
        public DeliveryTariff DeliveryPrice { get; set; }
        public decimal FullPrice { get; set; }
        public string DeliveryAddress { get; set; }
        public OrderStatus Status { get; set; }
    }
}
