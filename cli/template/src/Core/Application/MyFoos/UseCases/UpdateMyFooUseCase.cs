using Optivem.Atomiv.Core.Application;
using Optivem.Atomiv.Core.Domain;
using Optivem.Cli.Core.Application.MyFoos.Requests;
using Optivem.Cli.Core.Application.MyFoos.Responses;
using Optivem.Cli.Core.Domain.MyFoos.Entities;
using Optivem.Cli.Core.Domain.MyFoos.Repositories;
using Optivem.Cli.Core.Domain.MyFoos.ValueObjects;

namespace Optivem.Cli.Core.Application.MyFoos.UseCases
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
