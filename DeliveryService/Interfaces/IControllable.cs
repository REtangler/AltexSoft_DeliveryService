using System.Collections.Generic;
using System.Threading.Tasks;
using AltexFood_Delivery.BLL.Models;

namespace AltexFood_Delivery.BLL.Interfaces
{
    public interface IControllable
    {
        void AddPcPartToDb(IProduceable product);
        void AddPcPeripheralToDb(IProduceable product);
        void AddPcPartToOrder(int orderId, int itemId);
        void AddPcPeripheralToOrder(int orderId, int itemId);
        void DeleteEmptyOrder(int orderId);
        Order CreateOrder(string phoneNumber, string address);
        bool CanAddPcPeripheralsToOrder(int choice);
        bool CanAddPcPartsToOrder(int choice);
        IList<Order> GetOrders();
        IEnumerable<PcPeripheral> GetPcPeripherals();
        IEnumerable<PcPart> GetPcParts();
        Task<decimal> ConvertUahTo(decimal money, string convertTo);
    }
}
