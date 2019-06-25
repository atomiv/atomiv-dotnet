namespace Optivem.Framework.Core.Common
{
    public interface IFactory<TResult>
    {
        TResult Create();
    }
}
