namespace Optivem.Core.Domain
{
    public class AggregateRoot<TIdentity> : Entity<TIdentity>, IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
    {
        public AggregateRoot(TIdentity id) 
            : base(id)
        {
        }
    }
}
