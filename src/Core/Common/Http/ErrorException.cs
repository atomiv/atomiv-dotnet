using System;
using System.Runtime.Serialization;

namespace Atomiv.Core.Common.Http
{
    public class ErrorException : Exception
    {
        public ErrorException(ClientResponse clientResponse)
        {
            ClientResponse = clientResponse;
        }

        public ClientResponse ClientResponse { get; private set; }

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