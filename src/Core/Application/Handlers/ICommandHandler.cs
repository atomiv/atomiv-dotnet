using System;
using System.Collections.Generic;
using System.Text;

namespace Atomiv.Core.Application.Handlers
{
    public interface ICommandHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : ICommand<TResponse>
    {
    }
}
