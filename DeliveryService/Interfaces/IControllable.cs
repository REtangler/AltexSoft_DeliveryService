using DeliveryService.Models;

namespace DeliveryService.Interfaces
{
    public interface IControllable
    {
        IStorable GetStorage();
        void SaveBusinessData(int choice, IProduceable product);
        void SaveClientData(int choice, int orderId, int itemId);
        void DeleteEmptyOrder(int orderId);
        Order CreateOrder(string phoneNumber, string address);
    }
}
