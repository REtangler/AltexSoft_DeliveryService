using System.Threading.Tasks;
using AltexFood_Delivery.BLL.Models;

namespace AltexFood_Delivery.BLL.Interfaces
{
    public interface IPresentable
    {
        Task Start();
        Task StartBusinessDialogue();
        Task<int> StartClientDialogue();
        Task<int?> AddPcPartsToOrder();
        Task<int?> AddPcPeripheralsToOrder();
        PcPeripheral GetPcPeripheralInfo();
        PcPart GetPcPartInfo();
        string GetClientAddress();
        string GetClientPhoneNumber();
        Task ShowOrders();
        Task ShowPcPeripherals();
        Task ShowPcParts();
        Task ChooseCurrency();
    }
}
