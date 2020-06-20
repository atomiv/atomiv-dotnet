using Atomiv.Core.Application;
using Atomiv.Core.Domain;
using Cli.Core.Application.MyFoos.Requests;
using Cli.Core.Application.MyFoos.Responses;
using Cli.Core.Domain.MyFoos.Entities;
using Cli.Core.Domain.MyFoos.Repositories;
using Cli.Core.Domain.MyFoos.ValueObjects;

namespace Cli.Core.Application.MyFoos.UseCases
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