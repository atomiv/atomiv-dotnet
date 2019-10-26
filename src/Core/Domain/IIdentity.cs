using System;

namespace Optivem.Framework.Core.Domain
{
    public interface IIdentity
    {
    }

    public interface IIdentity<TId> : IIdentity
    {
        TId Id { get; }
    }
}