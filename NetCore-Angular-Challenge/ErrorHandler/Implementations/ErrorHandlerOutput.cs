using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ErrorHandler.Implementations
{
    public class ErrorHandlerOutput
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public object Result { get; set; }

        public ErrorHandlerOutput(HttpStatusCode httpStatusCode, object result)
        {
            HttpStatusCode = httpStatusCode;
            Result = result;
        }
    }
}
