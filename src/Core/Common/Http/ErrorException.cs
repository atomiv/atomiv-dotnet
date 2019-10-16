using System;
using System.Runtime.Serialization;

namespace Optivem.Framework.Core.Common.Http
{
    public class ErrorException : Exception
    {
        public ErrorException(IClientResponse clientResponse)
        {
            ClientResponse = clientResponse;
        }

        public IClientResponse ClientResponse { get; private set; }

        public ErrorException(string message) : base(message)
        {
        }

        public ErrorException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ErrorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}