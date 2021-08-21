using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using AltexFood_Delivery.DAL.Enums;

namespace AltexFood_Delivery.DAL.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public int ProductId { get; set; }

        [NotMapped]
        public IList<Product> Products { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int DeliverymanId { get; set; }
        public Deliveryman Deliveryman { get; set; }
        public DateTime OrderDateTime { get; set; }
        public DateTime DeliveredDateTime { get; set; }
        public DeliveryTariff DeliveryPrice { get; set; }
        public decimal FullPrice { get; set; }
        public string DeliveryAddress { get; set; }
        public OrderStatus Status { get; set; }
    }
}
