using DeliveryService.Models;

namespace DeliveryService.Interfaces
{
    public interface IControllable
    {
        IStorable GetStorage();
        void AddPcPartToDb(IProduceable product);
        void AddPcPeripheralToDb(IProduceable product);
        void AddPcPartToOrder(int orderId, int itemId);
        void AddPcPeripheralToOrder(int orderId, int itemId);
        void DeleteEmptyOrder(int orderId);
        Order CreateOrder(string phoneNumber, string address);
    }
}
