using System;

namespace Optivem.Atomiv.Core.Application
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class BaseRequestActionAttribute : Attribute
    {
        public BaseRequestActionAttribute(string action)
        {
            Action = action;
        }

        public BaseRequestActionAttribute(object action)
            : this(action?.ToString())
        {

        }

        public string Action { get; }

        public override string ToString()
        {
            return Action;
        }
    }
}
