using System;
using System.Runtime.Serialization;

namespace Optivem.Atomiv.Core.Application
{
    public class ValidationException : ApplicationException
    {
        public ValidationException()
        {
        }

        public ValidationException(string message) : base(message)
        {
        }

        public ValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ValidationException(Exception innerException) : base(innerException)
        {
        }

        public ValidationException(IRequestValidationResult result)
        {
            Result = result;
        }

        protected ValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public IRequestValidationResult Result { get; private set; }
    }
}