namespace Atomiv.Core.Domain
{
    public interface IReadonlyEntity<TIdentity>
    {
        public TIdentity Id { get; }
    }
}
