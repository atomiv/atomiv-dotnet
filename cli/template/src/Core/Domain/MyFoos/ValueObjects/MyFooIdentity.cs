using Atomiv.Core.Domain;

namespace Cli.Core.Domain.MyFoos.ValueObjects
{
    public class MyFooIdentity : Identity<int>
    {
        public static readonly MyFooIdentity Null = new MyFooIdentity(0);

        public MyFooIdentity(int id) : base(id)
        {
        }
    }
}
