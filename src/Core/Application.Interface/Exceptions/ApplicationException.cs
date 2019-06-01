using System;
using System.Runtime.Serialization;

namespace Optivem.Core.Application
{
    public class ApplicationException : Exception
    {
        public ApplicationException()
        {
        }

        public ApplicationException(string message) : base(message)
        {
        }

        public ApplicationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ApplicationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
