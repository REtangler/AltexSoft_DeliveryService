using System.Collections.Generic;
using DeliveryService.Interfaces;

namespace DeliveryService.Models
{
    public class Order : IOrder
    {
        public int Id { get; set; }

        public IList<PcPart> PcParts { get; set; }

        public IList<PcPeripheral> PcPeripherals { get; set; }

        private decimal _fullPrice;
        public decimal FullPrice
        {
            get
            {
                RecalculatePrice();
                return _fullPrice;
            }
            set => _fullPrice = value;
        }

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

        private void RecalculatePrice()
        {
            _fullPrice = default;

            if (PcParts.Count is 0 && PcPeripherals.Count is 0)
                return;

            foreach (var pcPart in PcParts)
            {
                _fullPrice += pcPart.Price;
            }

            foreach (var pcPeripheral in PcPeripherals)
            {
                _fullPrice += pcPeripheral.Price;
            }
        }
    }
}
