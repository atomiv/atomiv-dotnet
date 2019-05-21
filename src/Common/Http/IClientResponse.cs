using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Optivem.Common.Http
{
    public interface IClientResponse
    {
        bool IsSuccessStatusCode { get; }

        HttpStatusCode StatusCode { get; }

        string ContentString { get; }
    }
}
