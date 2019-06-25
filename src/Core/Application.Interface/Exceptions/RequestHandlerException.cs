﻿using System;
using System.Runtime.Serialization;

namespace Optivem.Framework.Core.Application
{
    public class RequestHandlerException : ApplicationException
    {
        public RequestHandlerException()
        {
        }

        public RequestHandlerException(string message) : base(message)
        {
        }

        public RequestHandlerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RequestHandlerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
