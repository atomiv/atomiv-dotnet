using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Atomiv.Infrastructure.AspNetCore
{
    public class RequestHeader
    {
        public RequestHeader(string header, string value)
        {
            Header = header;
            Value = value;
        }

        public string Header { get; }

        public string Value { get; }
    }
}
