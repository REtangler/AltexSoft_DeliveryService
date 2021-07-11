using System.Threading.Tasks;
using DeliveryService.Utils;
using DeliveryService.UI;

namespace DeliveryService
{
    internal static class Program
    {
        private static async Task Main()
        {
            var serializer = new Serializer();
            var regExp = new Validator();
            var logger = new Logger();
            var currencyRetriever = new CurrencyRetriever();

            var data = serializer.DeserializeFromFile();

            var controller = new Controller(data, serializer, currencyRetriever);

            var presenter = new Presenter(controller, regExp, logger);

            await presenter.Start();
        }
    }
}
