using System.Threading.Tasks;

namespace Atomiv.Core.Application
{
    public interface IRequestAuthorizer<TRequest>
    {
        Task<RequestAuthorizationResult> AuthorizeAsync(TRequest request);
    }
}
