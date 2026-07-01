using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UniSystemApi.Core.Exceptions;

namespace UniSystemApi.Filter
{
    public class ApiExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            int statusCode = 500;
            string message = "Internal Server Error. Something went wrong!";

            if (context.Exception is NotFoundException)
            {
                statusCode = 404;
                message = context.Exception.Message;
            }
            else if (context.Exception is BusinessException)
            {
                statusCode = 400;
                message = context.Exception.Message;
            }
            else
            {
                message = context.Exception.Message;
            }

            var response = new
            {
                IsSuccess = false,
                Message = message
            };

            context.Result = new JsonResult(response)
            {
                StatusCode = statusCode
            };
            context.ExceptionHandled = true;
        }
    }
}
