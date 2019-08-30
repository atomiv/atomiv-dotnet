using Optivem.Framework.Core.Domain;
using Optivem.Cli.Core.Domain.MyFoos.ValueObjects;

namespace Optivem.Cli.Core.Domain.MyFoos.Factories
{
    public class MyFooIdentityFactory : IIdentityFactory<MyFooIdentity, int>
    {
        public MyFooIdentity Create(int id)
        {
            return new MyFooIdentity(id);
        }
    }
}
