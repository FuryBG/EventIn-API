using Microsoft.AspNetCore.Mvc.Filters;

namespace PollApi.Filters
{
    public class ExceptionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("TEST");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("TEST1");
        }
    }
}
