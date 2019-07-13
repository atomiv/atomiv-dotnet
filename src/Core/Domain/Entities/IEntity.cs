namespace Optivem.Framework.Core.Domain
{
    public interface IEntity
    {
    }

    public interface IEntity<TIdentity> : IEntity
        where TIdentity : IIdentity
    {
        TIdentity Id { get; }
    }
}