using System.Security.Principal;

namespace Optivem.Atomiv.Template.Core.Application
{
    public interface IRequestContext
    {
        public IPrincipal User { get; }
    }
}
