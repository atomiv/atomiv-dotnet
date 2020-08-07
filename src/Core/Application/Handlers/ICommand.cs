using System;
using System.Collections.Generic;
using System.Text;

namespace Atomiv.Core.Application.Handlers
{
    public interface ICommand<TResponse> : IRequest<TResponse>
    {
    }
}
