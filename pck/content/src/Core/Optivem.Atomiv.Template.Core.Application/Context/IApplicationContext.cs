using Optivem.Atomiv.Core.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Atomiv.Template.Core.Application.Context
{
    public interface IApplicationContext : IApplicationService
    {
        bool IsPromotionDay { get; }
    }
}
