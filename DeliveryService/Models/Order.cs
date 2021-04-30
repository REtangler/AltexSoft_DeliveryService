using System.Collections.Generic;
using DeliveryService.Interfaces;

namespace DeliveryService.Models
{
    public class Order : IOrder
    {
        public int Id { get; set; }

        public IList<PcPart> PcParts { get; set; }

        public IList<PcPeripheral> PcPeripherals { get; set; }

        public decimal FullPrice { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public Order(int id, IList<PcPart> pcParts, IList<PcPeripheral> pcPeripherals)
        {
            Id = id;
            PcParts = pcParts;
            PcPeripherals = pcPeripherals;
        }

        public Order()
        {
            PcParts = new List<PcPart>();
            PcPeripherals = new List<PcPeripheral>();
        }

        public void RecalculatePrice()
        {
            if (PcParts.Count is 0 && PcPeripherals.Count is 0)
            {
                FullPrice = default;
                return;
            }

            foreach (var pcPart in PcParts)
            {
                FullPrice += pcPart.Price;
            }

            foreach (var pcPeripheral in PcPeripherals)
            {
                FullPrice += pcPeripheral.Price;
            }
        }
    }
}
