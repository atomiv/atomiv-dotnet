namespace Atomiv.Core.Application
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }

    public interface IUnitOfWorkFactory<TUnitOfWork> : IUnitOfWorkFactory
        where TUnitOfWork : IUnitOfWork
    {
        new TUnitOfWork Create();
    }
}