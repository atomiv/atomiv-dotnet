using System;
using System.Runtime.Serialization;

namespace Optivem.Atomiv.Core.Application
{
    public class ExistenceException : ApplicationException
    {
        public ExistenceException()
        {
        }

        public ExistenceException(string message) : base(message)
        {
        }

        public ExistenceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ExistenceException(Exception innerException) : base(innerException)
        {
        }

        protected ExistenceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}