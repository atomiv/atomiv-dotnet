namespace Atomiv.Core.Application
{
    public class RequestAuthorizationError
    {
        public RequestAuthorizationError(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; private set; }
    }
}
