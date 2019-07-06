using System;
using System.Runtime.Serialization;

namespace Optivem.Framework.Core.Common.WebAutomation
{
    public class WebAutomationException : Exception
    {
        public WebAutomationException()
        {
        }

        public WebAutomationException(string message) : base(message)
        {
        }

        public WebAutomationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected WebAutomationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
