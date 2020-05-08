using System.Security.Principal;

namespace Optivem.Atomiv.Core.Application
{
    public interface IApplicationUser : IPrincipal
    {
        bool HasActionPermission(string action);
    }
}
