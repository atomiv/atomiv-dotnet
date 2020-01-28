namespace Optivem.Atomiv.Core.Common.Http
{
    public interface IControllerClientFactory
    {
        IControllerClient Create(string controllerUri);
    }
}