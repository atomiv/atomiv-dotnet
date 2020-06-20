using Atomiv.Core.Application;
using Atomiv.Core.Domain;
using Cli.Core.Application.MyFoos.Requests;
using Cli.Core.Application.MyFoos.Responses;
using Cli.Core.Domain.MyFoos.Entities;
using Cli.Core.Domain.MyFoos.Repositories;
using Cli.Core.Domain.MyFoos.ValueObjects;

namespace Cli.Core.Application.MyFoos.UseCases
{
    public class UpdateMyFooUseCase : UpdateAggregateUseCase<IMyFooRepository, UpdateMyFooRequest, UpdateMyFooResponse, MyFoo, MyFooIdentity, int>
    {
        public UpdateMyFooUseCase(IUnitOfWork unitOfWork, IResponseMapper responseMapper) 
            : base(unitOfWork, responseMapper)
        {
        }

        protected override MyFooIdentity GetIdentity(int id)
        {
            return new MyFooIdentity(id);
        }

        protected override void Update(MyFoo aggregateRoot, UpdateMyFooRequest request)
        {
            aggregateRoot.FirstName = request.FirstName;
            aggregateRoot.LastName = request.LastName;
        }
    }
}
