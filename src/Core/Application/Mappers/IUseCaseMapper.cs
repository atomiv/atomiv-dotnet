using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Framework.Core.Application.Mappers
{
    public interface IUseCaseMapper
    {
        U Map<T, U>(T source);
    }
}
