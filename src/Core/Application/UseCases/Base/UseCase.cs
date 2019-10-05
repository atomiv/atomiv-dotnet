using Optivem.Framework.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application
{
    public abstract class UseCase<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest
        where TResponse : IResponse
    {
        public  abstract Task<TResponse> HandleAsync(TRequest request);
    }
}
