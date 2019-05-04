namespace Optivem.Core.Domain
{
    public interface IEntity<TKey>
    {
        // TODO: VC: Refactor, only getter for Id
        TKey Id { get; set; }
    }
}
