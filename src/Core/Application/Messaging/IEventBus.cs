using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Atomiv.Core.Application
{
    public interface IEventBus
    {
        Task PublishAsync<TEvent>(TEvent evt);
    }
}
