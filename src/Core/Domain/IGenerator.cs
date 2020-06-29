namespace Atomiv.Core.Domain
{
    public interface IGenerator<T>
    {
        T Next();
    }
}
