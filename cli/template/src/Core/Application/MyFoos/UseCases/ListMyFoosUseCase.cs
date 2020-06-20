using Atomiv.Core.Application;
using Cli.Core.Application.MyFoos.Requests;
using Cli.Core.Application.MyFoos.Responses;
using Cli.Core.Domain.MyFoos.Entities;
using Cli.Core.Domain.MyFoos.Repositories;
using Cli.Core.Domain.MyFoos.ValueObjects;

namespace Cli.Core.Application.MyFoos.UseCases
{
    public class ListMyFoosUseCase : ListAggregatesUseCase<IMyFooRepository, ListMyFoosRequest, ListMyFoosResponse, ListMyFoosRecordResponse, MyFoo, MyFooIdentity, int>
    {
        public ListMyFoosUseCase(IMyFooRepository repository, ICollectionResponseMapper<MyFoo, ListMyFoosResponse> responseMapper) 
            : base(repository, responseMapper)
        {
        }
    }
}