using DeliveryService.Models;

namespace DeliveryService.Interfaces
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
    }
}
