using System.Threading.Tasks;

namespace Optivem.Atomiv.Core.Application
{
    public interface IRequestAuthorizer<TRequest>
    {
        Task<RequestAuthorizationResult> AuthorizeAsync(TRequest request);
    }
}
