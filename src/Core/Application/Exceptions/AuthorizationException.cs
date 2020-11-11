using System;
using System.Runtime.Serialization;

namespace Atomiv.Core.Application
{
    public class AuthorizationException : ApplicationException
    {
        public AuthorizationException()
        {
        }

        public AuthorizationException(string message) : base(message)
        {
        }

        public AuthorizationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public AuthorizationException(Exception innerException) : base(innerException)
        {
        }

        public AuthorizationException(RequestAuthorizationResult result)
        {
            Result = result;
        }

        protected AuthorizationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public RequestAuthorizationResult Result { get; private set; }
    }
}
