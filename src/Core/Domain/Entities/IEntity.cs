namespace Optivem.Core.Domain.Entities
{
    public interface IEntity
    {

    }

    public interface IEntity<TId> : IEntity
    {
        // TODO: VC: Refactor, only getter for Id
        TId Id { get; set; }
    }
}
