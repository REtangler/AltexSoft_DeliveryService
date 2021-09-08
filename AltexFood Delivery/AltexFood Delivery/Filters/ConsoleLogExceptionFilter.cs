using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace AltexFood_Delivery.Api.Filters
{
    public class ConsoleLogExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<string> _logger;

        public ConsoleLogExceptionFilter(ILogger<string> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.Log(LogLevel.Error, context.Exception, "Application failed at: " + context.Exception.InnerException);
        }
    }
}
