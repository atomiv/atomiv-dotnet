using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Optivem.Atomiv.Core.Common.Http
{
    public class RequestHeaderCollection
    {
        public RequestHeaderCollection(IEnumerable<RequestHeader> headers)
        {
            Headers = headers;
        }

        public RequestHeaderCollection(params RequestHeader[] headers)
            : this(headers.AsEnumerable())
        {
        }

        public IEnumerable<RequestHeader> Headers { get; }

        public RequestHeaderCollection Union(RequestHeaderCollection other)
        {
            var union = Headers.Union(other.Headers);
            return new RequestHeaderCollection(union);
        }
    }
}
