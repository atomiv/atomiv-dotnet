using Optivem.Atomiv.Core.Domain;

namespace Optivem.Cli.Core.Domain.MyFoos.ValueObjects
{
    public class MyFooIdentity : Identity<int>
    {
        public static readonly MyFooIdentity Null = new MyFooIdentity(0);

        public MyFooIdentity(int id) : base(id)
        {
        }
    }
}
