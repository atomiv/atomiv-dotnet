namespace Optivem.Atomiv.Core.Domain
{
    public interface IIdentityGenerator<TIdentity>
    {
        TIdentity Next();
    }
}
