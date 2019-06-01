using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Optivem.Core.Application
{
    public class RequestHandlerException : ApplicationException
    {
        public RequestHandlerException()
        {
        }

        public RequestHandlerException(string message) : base(message)
        {
        }

        public RequestHandlerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RequestHandlerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
