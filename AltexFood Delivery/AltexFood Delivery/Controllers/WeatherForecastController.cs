using System;
using System.Collections.Generic;
using System.Linq;
using AltexFood_Delivery.BLL.Data;
using AltexFood_Delivery.BLL.Models;
using AltexFood_Delivery.BLL.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Controller = AltexFood_Delivery.BLL.Utils.Controller;

namespace AltexFood_Delivery.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<PcPart> Get()
        {
            var ctrl = new Controller(new Storage(), new Serializer(), new CurrencyRetriever(), new Cache());
            return ctrl.GetPcParts().ToList();

            /*var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();*/
        }
    }
}
