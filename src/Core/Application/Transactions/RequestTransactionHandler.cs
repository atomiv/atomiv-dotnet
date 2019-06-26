using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application
{
    public class RequestTransactionHandler<TRequest> : IRequestTransactionHandler<TRequest>
        where TRequest : IRequest
    {
        public Task HandleAsync(TRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
