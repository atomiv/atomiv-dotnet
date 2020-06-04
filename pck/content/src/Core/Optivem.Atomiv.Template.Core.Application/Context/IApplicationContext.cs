using Optivem.Atomiv.Core.Application;

namespace Optivem.Atomiv.Template.Core.Application.Context
{
    public interface IApplicationContext : IApplicationService
    {
        bool IsPromotionDay { get; }
    }
}
