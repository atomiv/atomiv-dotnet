using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Atomiv.Core.Application
{
    public interface IQueryBus
    {
        Task<TResponse> SendAsync<TResponse>(IQuery<TResponse> query);
    }
}
