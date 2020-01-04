using System;
using System.Runtime.Serialization;

namespace Optivem.Framework.Core.Application
{
    public class ValidationException : ApplicationException
    {
        public ValidationException(IRequestValidationResult result)
        {
            Result = result;
        }

        public ValidationException()
        {
        }

        public ValidationException(string message) : base(message)
        {
        }

        public ValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public IRequestValidationResult Result { get; private set; }
    }
}