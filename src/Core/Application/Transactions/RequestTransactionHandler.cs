using System;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Core.Application
{
    public class RequestTransactionHandler<TRequest> : IRequestTransactionHandler<TRequest>
    {
        public Task HandleAsync(TRequest request)
        {
            throw new NotImplementedException();
        }
    }
}