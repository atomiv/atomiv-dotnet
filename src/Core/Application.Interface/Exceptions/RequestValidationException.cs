using System;
using System.Runtime.Serialization;

namespace Optivem.Core.Application
{
    public class RequestValidationException : Exception
    {
        public RequestValidationException(IRequestValidationResult result)
        {
            Result = result;
        }

        public RequestValidationException()
        {
        }

        public RequestValidationException(string message) : base(message)
        {
        }

        public RequestValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RequestValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public IRequestValidationResult Result { get; private set; }
    }
}