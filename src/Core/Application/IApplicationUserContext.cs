namespace Atomiv.Core.Application
{
    public interface IApplicationUserContext<TRequestType>
    {
        public IApplicationUser<TRequestType> ApplicationUser { get; }
    }

    public interface IApplicationUserContext<TApplicationUser, TRequestType> : IApplicationUserContext<TRequestType> 
        where TApplicationUser : IApplicationUser<TRequestType>
    {
        public new TApplicationUser ApplicationUser { get; }
    }
}
