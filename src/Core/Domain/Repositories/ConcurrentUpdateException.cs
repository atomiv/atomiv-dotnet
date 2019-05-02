using System;
using System.Runtime.Serialization;

namespace Optivem.Framework.Core.Domain.Repositories
{
    public class ConcurrentUpdateException : Exception
    {
        public ConcurrentUpdateException()
        {
        }

        public ConcurrentUpdateException(string message) : base(message)
        {
        }

        public ConcurrentUpdateException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ConcurrentUpdateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
