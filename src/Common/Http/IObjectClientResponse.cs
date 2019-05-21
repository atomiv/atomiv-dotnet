using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Optivem.Common.Http
{
    public interface IObjectClientResponse<T> : IClientResponse
    {
        T Content { get; }

        IProblemDetails ProblemDetails { get; }
    }
}
