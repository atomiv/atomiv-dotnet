using System.Collections.Generic;

namespace Optivem.Core.Application
{
    public interface IFindAllUseCase<TResponse> : IUseCase<IEnumerable<TResponse>>
    {
    }
}
