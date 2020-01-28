using System;
using System.Runtime.Serialization;

namespace Optivem.Atomiv.Core.Domain
{
    public class EntityException : DomainException
    {
        public EntityException()
        {
        }

        public EntityException(string message) : base(message)
        {
        }

        public EntityException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EntityException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}