namespace Atomiv.Core.Common.Http
{
    public interface IContentControllerClientFactory
    {
        IContentControllerClient Create(string controllerUri);
    }
}