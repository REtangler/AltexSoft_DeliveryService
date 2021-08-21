using System.Threading.Tasks;
using AltexFood_Delivery.BLL.Data;
using AltexFood_Delivery.BLL.Utils;
using AltexFood_Delivery.BLL.UI;

namespace AltexFood_Delivery.BLL
{
    internal static class Program
    {
        private static async Task Main()
        {
            var serializer = new Serializer();
            var cache = new Cache();
            var regExp = new Validator();
            var logger = new Logger();
            var currencyRetriever = new CurrencyRetriever();

            var data = serializer.DeserializeFromFile();

            var controller = new Controller(data, serializer, currencyRetriever, cache);

            var presenter = new Presenter(controller, regExp, logger);

            await presenter.Start();
        }
    }
}
