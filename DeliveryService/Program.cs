using DeliveryService.Data;
using DeliveryService.Logic;
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

            var controller = new Controller(data);

            var presenter = new Presenter(controller, regExp, logger);

            presenter.Start();
        }
    }
}
