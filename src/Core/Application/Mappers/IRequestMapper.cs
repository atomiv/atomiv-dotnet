namespace Optivem.Core.Application
{
    public interface IRequestMapper<TRequest, TEntity>
    {
        TEntity Map(TRequest request);
    }

    public interface IRequestMapper
    {
        TEntity Map<TRequest, TEntity>(TRequest request);
    }
}