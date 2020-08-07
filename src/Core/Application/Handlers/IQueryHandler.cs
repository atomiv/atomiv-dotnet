using System;
using System.Collections.Generic;
using System.Text;

namespace Atomiv.Core.Application
{
    public interface IQueryHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IQuery<TResponse>
    {
    }
}
