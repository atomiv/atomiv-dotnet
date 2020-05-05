using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Core.Application
{
    public class RequestAuthorizationHandler<TRequest> : IRequestAuthorizationHandler<TRequest>
    {
        private IEnumerable<IRequestAuthorizer<TRequest>> _authorizers;

        public RequestAuthorizationHandler(IEnumerable<IRequestAuthorizer<TRequest>> authorizers)
        {
            _authorizers = authorizers;
        }

        public async Task HandleAsync(TRequest request)
        {
            foreach(var authorizer in _authorizers)
            {
                var result = await authorizer.AuthorizeAsync(request);

                if (!result.IsAuthorized)
                {
                    throw new AuthorizationException(result);
                }
            }
        }
    }
}
