using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PollApi.Contracts;

namespace PollApi.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            Error error = new Error(context.HttpContext.Response.StatusCode, context.Exception.Message);
            context.Result = new JsonResult(error) { StatusCode = 400 };
        }
    }
}
