using System.Collections.Generic;

namespace Optivem.Framework.Core.Application.Ports.UseCases
{
    public interface IFindAllUseCase<TResponse> : IUseCase<IEnumerable<TResponse>>
    {
    }
}
