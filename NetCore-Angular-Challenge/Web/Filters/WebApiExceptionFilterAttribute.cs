using ErrorHandler.Implementations;
using ErrorHandler.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Web.Filters
{
    public class WebApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IErrorHandler _errorHandler;

        public WebApiExceptionFilterAttribute(IErrorHandler errorHandler)
        {
            _errorHandler = errorHandler;
        }

        public override void OnException(ExceptionContext exceptionContext)
        {
            ErrorHandlerOutput errorHandlerOutput = _errorHandler.HandleException(exceptionContext.Exception);
            exceptionContext.HttpContext.Response.StatusCode = (int)errorHandlerOutput.HttpStatusCode;
            exceptionContext.Result = new JsonResult(errorHandlerOutput.Result);
            exceptionContext.ExceptionHandled = true;
        }
    }
}
