using System;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application
{
    public class RequestTransactionHandler<TRequest> : IRequestTransactionHandler<TRequest>
    {
        public Task HandleAsync(TRequest request)
        {
            throw new NotImplementedException();
        }
    }
}