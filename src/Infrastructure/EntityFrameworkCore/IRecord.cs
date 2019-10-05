using Optivem.Framework.Core.Domain;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public interface IRecord : IIdentity
    {

    }

    public interface IRecord<TId> : IRecord, IIdentity<TId>
    {
    }
}
