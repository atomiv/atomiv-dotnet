using Atomiv.Core.Application;
using Atomiv.Core.Domain;
using Cli.Core.Application.MyFoos.Requests;
using Cli.Core.Application.MyFoos.Responses;
using Cli.Core.Domain.MyFoos.Entities;
using Cli.Core.Domain.MyFoos.Repositories;
using Cli.Core.Domain.MyFoos.ValueObjects;

namespace Cli.Core.Application.MyFoos.UseCases
{
    public class DeleteMyFooUseCase : DeleteAggregateCase<IMyFooRepository, DeleteMyFooRequest, DeleteMyFooResponse, MyFoo, MyFooIdentity, int>
    {
        public DeleteMyFooUseCase(IUnitOfWork unitOfWork, IIdentityFactory<MyFooIdentity, int> identityFactory) 
            : base(unitOfWork, identityFactory)
        {
        }
    }
}
