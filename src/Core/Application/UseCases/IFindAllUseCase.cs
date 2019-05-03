using System.Collections.Generic;

namespace Optivem.Framework.Core.Application.UseCases
{
    public interface IFindAllUseCase<TResponse> : IUseCase<IEnumerable<TResponse>>
    {
    }
}
