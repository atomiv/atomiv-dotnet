using Optivem.Framework.Core.Domain;
using Optivem.Cli.Core.Domain.MyFoos.Entities;
using Optivem.Cli.Core.Domain.MyFoos.ValueObjects;

namespace Optivem.Cli.Core.Domain.MyFoos.Repositories
{
    public interface IMyFooRepository : ICrudRepository<MyFoo, MyFooIdentity>
    {
    }
}