using ErrorHandler.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ErrorHandler.Implementations
{
    public class ErrorHandler : IErrorHandler
    {
        public ErrorHandlerOutput HandleException(Exception exception)
        {
            //notifications (CrossCutting.Message).

            return new ErrorHandlerOutput(HttpStatusCode.InternalServerError, new
            {
                exceptiontype = exception.GetType().Name,
                message = exception.Message,
                stacktrace = exception.StackTrace
            });
        }
    }
}
