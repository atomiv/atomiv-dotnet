using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Domain;
using Optivem.Cli.Core.Application.MyFoos.Requests;
using Optivem.Cli.Core.Application.MyFoos.Responses;
using Optivem.Cli.Core.Domain.MyFoos.Entities;
using Optivem.Cli.Core.Domain.MyFoos.Repositories;
using Optivem.Cli.Core.Domain.MyFoos.ValueObjects;

namespace Optivem.Cli.Core.Application.MyFoos.UseCases
{
    public class FindMyFooUseCase : FindAggregateUseCase<IMyFooRepository, FindMyFooRequest, FindMyFooResponse, MyFoo, MyFooIdentity, int>
    {
        public FindMyFooUseCase(IUnitOfWork unitOfWork, IResponseMapper responseMapper)
            : base(unitOfWork, responseMapper)
        {
        }

        protected override MyFooIdentity GetIdentity(int id)
        {
            return new MyFooIdentity(id);
        }
    }
}