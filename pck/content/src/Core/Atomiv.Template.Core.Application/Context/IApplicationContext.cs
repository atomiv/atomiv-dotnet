using Atomiv.Core.Application;

namespace Atomiv.Template.Core.Application.Context
{
    public interface IApplicationContext : IApplicationService
    {
        bool IsPromotionDay { get; }
    }
}
