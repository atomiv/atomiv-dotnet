using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Framework.Core.Application.UseCases
{
    public interface ICommand<TRequest, TResponse> : IRequest<TResponse>
    {
        TRequest Request { get; set; }
    }
}
