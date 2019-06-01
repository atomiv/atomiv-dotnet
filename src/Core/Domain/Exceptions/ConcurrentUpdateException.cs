using System;
using System.Runtime.Serialization;

namespace Optivem.Core.Domain
{
    public class ConcurrentUpdateException : RepositoryException
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