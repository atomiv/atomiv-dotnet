using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Framework.Core.Application
{
    // TODO: VC: Implement interceptors for: info logging, exception logging, auto retries, transactions, validation, authorization

    public interface IRequestInterceptor<TRequest, TResponse>
        where TRequest : IRequest
    {
    }
}
