using Optivem.Atomiv.Core.Application;
using Optivem.Atomiv.Core.Domain;
using Optivem.Cli.Core.Application.MyFoos.Requests;
using Optivem.Cli.Core.Application.MyFoos.Responses;
using Optivem.Cli.Core.Domain.MyFoos.Entities;
using Optivem.Cli.Core.Domain.MyFoos.Repositories;
using Optivem.Cli.Core.Domain.MyFoos.ValueObjects;

namespace Optivem.Cli.Core.Application.MyFoos.UseCases
{
    public class DeleteMyFooUseCase : DeleteAggregateCase<IMyFooRepository, DeleteMyFooRequest, DeleteMyFooResponse, MyFoo, MyFooIdentity, int>
    {
        public DeleteMyFooUseCase(IUnitOfWork unitOfWork, IIdentityFactory<MyFooIdentity, int> identityFactory) 
            : base(unitOfWork, identityFactory)
        {
        }
    }
}
