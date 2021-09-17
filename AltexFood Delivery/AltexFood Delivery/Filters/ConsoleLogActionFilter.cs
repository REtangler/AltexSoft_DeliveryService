using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AltexFood_Delivery.Api.Filters
{
    public class ConsoleLogActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine(context.HttpContext.Request.Body);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("Executing: " + context.HttpContext.Request.Body);
        }
    }
}
