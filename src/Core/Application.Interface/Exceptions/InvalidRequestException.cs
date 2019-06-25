using System;
using System.Runtime.Serialization;

namespace Optivem.Core.Application
{
    public class InvalidRequestException : Exception
    {
        public InvalidRequestException(IRequestValidationResult result)
        {
            Result = result;
        }

        public InvalidRequestException()
        {
        }

        public InvalidRequestException(string message) : base(message)
        {
        }

        public InvalidRequestException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidRequestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public IRequestValidationResult Result { get; private set; }
    }
}