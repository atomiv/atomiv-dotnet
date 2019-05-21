namespace Optivem.Core.Application.Services
{
    public class BaseService : IService
    {
        public BaseService(IUseCaseMediator mediator)
        {
            Mediator = mediator;
        }

        protected IUseCaseMediator Mediator { get; private set; }
    }
}
