using Atomiv.Core.Domain;
using Cli.Core.Domain.MyFoos.Entities;
using Cli.Core.Domain.MyFoos.ValueObjects;

namespace Cli.Core.Domain.MyFoos.Repositories
{
    public interface IMyFooRepository : ICrudRepository<MyFoo, MyFooIdentity>
    {
    }
}