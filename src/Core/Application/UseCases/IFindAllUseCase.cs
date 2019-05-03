using System.Collections.Generic;

namespace Optivem.Framework.Core.Application.Ports.In.UseCases
{
    public interface IFindAllUseCase<TResponse> : IUseCase<IEnumerable<TResponse>>
    {
    }
}
