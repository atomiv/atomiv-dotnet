namespace Optivem.Atomiv.Core.Domain
{
    public class IdNameReadModel<TId>
    {
        public IdNameReadModel(TId id, string name)
        {
            Id = id;
            Name = name;
        }

        public TId Id { get; }

        public string Name { get; }
    }
}
