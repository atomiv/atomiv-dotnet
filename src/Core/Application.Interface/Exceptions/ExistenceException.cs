using System;
using System.Runtime.Serialization;

namespace Optivem.Framework.Core.Application
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

        protected ExistenceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}