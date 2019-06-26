using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Framework.Core.Application
{
    public interface ICommandUseCase<TRequest, TResponse> : IUseCase<TRequest, TResponse>
        where TRequest : IRequest
        where TResponse : IResponse
    {
    }
}
