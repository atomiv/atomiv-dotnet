namespace Optivem.Framework.Core.Domain
{
    public interface IAggregateRoot : IEntity
    {
    }

    public interface IAggregateRoot<TIdentity> : IEntity<TIdentity>, IAggregateRoot
        where TIdentity : IIdentity
    {
    }
}