using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AltexFood_Delivery.Api.Filters
{
    public class ConsoleLogExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<string> _logger;
        private readonly IWebHostEnvironment _env;

        public ConsoleLogExceptionFilter(ILogger<string> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }

        public void OnException(ExceptionContext context)
        {
            if (_env.IsProduction())
                _logger.Log(LogLevel.Error, "Something went wrong :/");
            else 
                _logger.Log(LogLevel.Error, context.Exception, "Application failed at: " + context.Exception.InnerException);
        }
    }
}
