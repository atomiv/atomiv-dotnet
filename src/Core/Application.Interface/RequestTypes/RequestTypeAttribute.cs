using System;

namespace Optivem.Atomiv.Core.Application
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class RequestTypeAttribute : Attribute
    {
        public RequestTypeAttribute(string requestType)
        {
            RequestType = requestType;
        }

        public RequestTypeAttribute(object requestType)
            : this(ToString(requestType))
        {

        }

        public string RequestType { get; }

        public override string ToString()
        {
            return RequestType;
        }

        private static string ToString(object requestType)
        {
            return requestType?.ToString();
        }
    }
}
