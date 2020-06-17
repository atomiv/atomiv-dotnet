using System.Collections.Generic;
using System.Security.Claims;

namespace Optivem.Atomiv.Core.Application
{
    public interface IApplicationUserSerializer<TApplicationUser, TRequestType> where TApplicationUser : IApplicationUser<TRequestType>
    {
        TApplicationUser Deserialize(IEnumerable<Claim> claims);

        IEnumerable<Claim> Serialize(TApplicationUser applicationUser);
    }
}
