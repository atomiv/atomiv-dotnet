namespace Optivem.Framework.Core.Domain
{
    public interface IIdentityGenerator<TIdentity>
    {
        TIdentity Next();
    }
}
