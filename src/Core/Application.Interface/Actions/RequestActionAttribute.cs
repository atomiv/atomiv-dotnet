using System;

namespace Optivem.Atomiv.Core.Application
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class RequestActionAttribute : Attribute
    {
        public RequestActionAttribute(string action)
        {
            Action = action;
        }

        public RequestActionAttribute(object action)
            : this(ToString(action))
        {

        }

        public string Action { get; }

        public override string ToString()
        {
            return Action;
        }

        private static string ToString(object action)
        {
            return action?.ToString();
        }
    }
}
