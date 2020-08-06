namespace Atomiv.Core.Application
{
    public interface IApplicationUser<TRequestType>
    {
        bool CanExecute(TRequestType requestType);
    }
}
