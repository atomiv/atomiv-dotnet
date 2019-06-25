using System;
using System.Runtime.Serialization;

namespace Optivem.Core.Application
{
    public class NotFoundRequestException : RequestHandlerException
    {
        public NotFoundRequestException()
        {
        }

        public NotFoundRequestException(string message) : base(message)
        {
        }

        public NotFoundRequestException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotFoundRequestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
