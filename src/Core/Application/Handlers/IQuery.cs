using System;
using System.Collections.Generic;
using System.Text;

namespace Atomiv.Core.Application
{
    public interface IQuery<TResponse> : IRequest<TResponse>
    {
    }
}
