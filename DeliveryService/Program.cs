using DeliveryService.Data;
using DeliveryService.UI;

namespace DeliveryService
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new Storage();

            var controller = new Controller();

            data = controller.Start(data);
        }
    }
}
