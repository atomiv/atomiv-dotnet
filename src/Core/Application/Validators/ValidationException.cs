using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Optivem.Core.Application
{
    public class ValidationException : Exception
    {
        public ValidationException(IValidationResult result)
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

        public IValidationResult Result { get; private set; }
    }
}
