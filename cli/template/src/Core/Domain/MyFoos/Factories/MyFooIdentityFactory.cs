using Atomiv.Core.Domain;
using Cli.Core.Domain.MyFoos.ValueObjects;

namespace Cli.Core.Domain.MyFoos.Factories
{
    public class MyFooIdentityFactory : IIdentityFactory<MyFooIdentity, int>
    {
        public MyFooIdentity Create(int id)
        {
            return new MyFooIdentity(id);
        }
    }
}
