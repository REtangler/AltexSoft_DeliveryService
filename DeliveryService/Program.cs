using System.Threading.Tasks;
using DeliveryService.Utils;
using DeliveryService.UI;

namespace DeliveryService
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serializer = new Serializer();
            var regExp = new Validator();
            var logger = new Logger();
            var exchanger = new CurrencyExchanger();

            var data = serializer.DeserializeFromFile();

            var controller = new Controller(data, serializer, exchanger);

            var presenter = new Presenter(controller, regExp, logger);

            await presenter.Start();
        }
    }
}
