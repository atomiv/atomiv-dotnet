using System.Threading.Tasks;

namespace Optivem.Atomiv.Core.Application
{
    public class RequestAuthorizationHandler<TRequest> : IRequestAuthorizationHandler<TRequest>
    {
        private IRequestAuthorizer<TRequest> _authorizer;

        public RequestAuthorizationHandler(IRequestAuthorizer<TRequest> authorizer)
        {
            _authorizer = authorizer;
        }

        public async Task HandleAsync(TRequest request)
        {
            var result = await _authorizer.AuthorizeAsync(request);

            if (!result.IsAuthorized)
            {
                throw new AuthorizationException(result);
            }
        }
    }
}
