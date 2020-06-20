using Atomiv.Core.Application;
using Atomiv.Core.Domain;
using Cli.Core.Application.MyFoos.Requests;
using Cli.Core.Application.MyFoos.Responses;
using Cli.Core.Domain.MyFoos.Entities;
using Cli.Core.Domain.MyFoos.Repositories;
using Cli.Core.Domain.MyFoos.ValueObjects;

namespace Cli.Core.Application.MyFoos.UseCases
{
    public class CreateMyFooUseCase : CreateAggregateUseCase<IMyFooRepository, CreateMyFooRequest, CreateMyFooResponse, MyFoo, MyFooIdentity, int>
    {
        public CreateMyFooUseCase(IUnitOfWork unitOfWork, IResponseMapper<MyFoo, CreateMyFooResponse> responseMapper)
            : base(unitOfWork, responseMapper)
        {
        }

        protected override MyFoo CreateAggregateRoot(MyFoo aggregateRoot, MyFooIdentity identity)
        {
            return new MyFoo(identity, aggregateRoot.FirstName, aggregateRoot.LastName);
        }

        protected override MyFoo CreateAggregateRoot(CreateMyFooRequest request)
        {
            return new MyFoo(MyFooIdentity.Null, request.FirstName, request.LastName);
        }
    }
}