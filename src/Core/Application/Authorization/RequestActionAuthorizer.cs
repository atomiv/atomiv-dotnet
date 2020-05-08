using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Core.Application.Authorization
{
    public class RequestActionAuthorizer<TRequest> : BaseRequestAuthorizer<TRequest>
    {
        private readonly IRequestContext _requestContext;

        public RequestActionAuthorizer(IRequestContext requestContext)
        {
            _requestContext = requestContext;
        }

        public override Task<RequestAuthorizationResult> AuthorizeAsync(TRequest request)
        {
            var type = typeof(TRequest);
            var customAttributeType = typeof(BaseRequestActionAttribute);
            var customAttribute = type.GetCustomAttributes(customAttributeType, false).FirstOrDefault() as BaseRequestActionAttribute;

            if(customAttribute == null)
            {
                return Task.FromResult(Success());
            }

            var action = customAttribute.Action;

            var user = _requestContext.User;

            var hasPermission = user.HasActionPermission(action);

            if(!hasPermission)
            {
                // TODO: VC: Translations, localizable and also maybe possibility to get this from actual project
                var errorMessage = $"Invalid action {action}";

                return Task.FromResult(Failure(errorMessage));
            }

            return Task.FromResult(Success());
        }
    }
}
