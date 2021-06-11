using DeliveryService.Data;
using DeliveryService.Utils;
using DeliveryService.UI;

namespace DeliveryService
{
    class Program
    {
        static void Main(string[] args)
        {
            var serializer = new Serializer();
            var cache = new Cache();
            var regExp = new Validator();
            var logger = new Logger();

            var data = serializer.DeserializeFromFile();

            var controller = new Controller(data, serializer, cache);

            var presenter = new Presenter(controller, regExp, logger);

            presenter.Start();
        }
    }
}
