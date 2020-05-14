namespace Optivem.Atomiv.Core.Application
{
    public interface IUserContext
    {
        public IUser User { get; }
    }

    public interface IUserContext<TUser> : IUserContext where TUser : IUser
    {
        public new TUser User { get; }
    }
}
