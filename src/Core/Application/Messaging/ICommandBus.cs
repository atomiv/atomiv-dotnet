using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Atomiv.Core.Application
{
    public interface ICommandBus
    {
        Task<TResponse> SendAsync<TResponse>(ICommand<TResponse> command);
    }
}
