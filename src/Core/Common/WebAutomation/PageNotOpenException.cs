using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Optivem.Framework.Core.Common.WebAutomation
{
    public class PageNotOpenException : WebAutomationException
    {
        public PageNotOpenException()
        {
        }

        public PageNotOpenException(string message) : base(message)
        {
        }

        public PageNotOpenException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PageNotOpenException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
