using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Atomiv.Core.Common.Http
{
    public class RequestHeader
    {
        public RequestHeader(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }

        public string Value { get; }
    }
}
