using Optivem.Atomiv.Core.Application;
using Optivem.Cli.Core.Application.MyFoos.Requests;
using Optivem.Cli.Core.Application.MyFoos.Responses;
using Optivem.Cli.Core.Domain.MyFoos.Entities;
using Optivem.Cli.Core.Domain.MyFoos.Repositories;
using Optivem.Cli.Core.Domain.MyFoos.ValueObjects;

namespace Optivem.Cli.Core.Application.MyFoos.UseCases
{
    public class ListMyFoosUseCase : ListAggregatesUseCase<IMyFooRepository, ListMyFoosRequest, ListMyFoosResponse, ListMyFoosRecordResponse, MyFoo, MyFooIdentity, int>
    {
        public ListMyFoosUseCase(IMyFooRepository repository, ICollectionResponseMapper<MyFoo, ListMyFoosResponse> responseMapper) 
            : base(repository, responseMapper)
        {
        }
    }
}