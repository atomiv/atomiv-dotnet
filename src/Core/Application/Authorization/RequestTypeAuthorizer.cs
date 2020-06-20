using System;
using System.Linq;
using System.Threading.Tasks;

namespace Atomiv.Core.Application.Authorization
{
    public class RequestTypeAuthorizer<TRequest, TRequestType> : BaseRequestAuthorizer<TRequest>
    {
        private readonly IApplicationUserContext<TRequestType> _requestContext;

        public RequestTypeAuthorizer(IApplicationUserContext<TRequestType> requestContext)
        {
            _requestContext = requestContext;
        }

        public override Task<RequestAuthorizationResult> AuthorizeAsync(TRequest request)
        {
            var type = typeof(TRequest);
            var customAttributeType = typeof(RequestTypeAttribute);
            var customAttribute = type.GetCustomAttributes(customAttributeType, false).FirstOrDefault() as RequestTypeAttribute;

            if(customAttribute == null)
            {
                return Task.FromResult(Success());
            }

            var requestTypeString = customAttribute.RequestType;

            var requestType = (TRequestType)Enum.Parse(typeof(TRequestType), requestTypeString);

            var user = _requestContext.ApplicationUser;

            var hasPermission = user.CanExecute(requestType);

            if(!hasPermission)
            {
                // TODO: VC: Translations, localizable and also maybe possibility to get this from actual project
                var errorMessage = $"Invalid request type {requestType}";

                return Task.FromResult(Failure(errorMessage));
            }

            return Task.FromResult(Success());
        }
    }
}
