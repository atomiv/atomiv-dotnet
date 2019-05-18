using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Core.Application
{
    public interface IBrowseUseCase<TRequest, TResponse> : IUseCase<TRequest, TResponse>
        where TRequest : IBrowseRequest
        where TResponse : IBrowseResponse
    {

    }
}
