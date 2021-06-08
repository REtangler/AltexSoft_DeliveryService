using DeliveryService.Data;
using DeliveryService.Utils;
using DeliveryService.UI;

namespace DeliveryService
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new Storage();
            var regExp = new Validator();
            var logger = new Logger();
            var exchanger = new CurrencyExchanger();

            var controller = new Controller(data);

            var presenter = new Presenter(controller, regExp, logger, exchanger);

            presenter.Start();
        }
    }
}
