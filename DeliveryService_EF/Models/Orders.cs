using System;
using System.Collections.Generic;
using DeliveryService_EF.Enums;

namespace DeliveryService_EF.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public IList<Products> ProductId { get; set; }
        public Clients ClientId { get; set; }
        public Deliverymen DeliverymanId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveredDate { get; set; }
        public DeliveryTariffs DeliveryPrice { get; set; }
        public decimal FullPrice { get; set; }
        public string DeliveryAddress { get; set; }
        public OrderStatus Status { get; set; }
    }
}
