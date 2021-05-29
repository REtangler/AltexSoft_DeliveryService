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
            var regExp = new RegExpression();
            var cache = new Cache();

            var data = serializer.DeserializeFromFile();

            var controller = new Controller(data, serializer, cache);

            var presenter = new Presenter(controller, regExp);

            presenter.Start();
        }
    }
}
