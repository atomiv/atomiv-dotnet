namespace Atomiv.Core.Domain
{
    public interface IReadonlyEntity<TIdentity>
    {
        public TIdentity Id { get; }

        public bool IsNew { get; }
    }
}
