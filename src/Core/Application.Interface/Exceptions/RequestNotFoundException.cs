using System;
using System.Runtime.Serialization;

namespace Optivem.Core.Application
{
    public class RequestNotFoundException : RequestHandlerException
    {
        public RequestNotFoundException()
        {
        }

        public RequestNotFoundException(string message) : base(message)
        {
        }

        public RequestNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RequestNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
