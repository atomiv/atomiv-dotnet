using System.Security.Principal;

namespace Optivem.Atomiv.Core.Application
{
    public interface IUser : IPrincipal
    {
        bool HasActionPermission(string action);
    }
}
