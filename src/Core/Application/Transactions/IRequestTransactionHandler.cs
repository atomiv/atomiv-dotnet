using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Framework.Core.Application
{
    public interface IRequestTransactionHandler<TRequest> : IRequestHandler<TRequest>
        where TRequest : IRequest
    {
    }
}
