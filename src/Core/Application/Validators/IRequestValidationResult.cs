using System.Collections.Generic;

namespace Optivem.Core.Application
{
    public interface IRequestValidationResult
    {
        bool IsValid { get; }

        IList<IRequestValidationError> Errors { get; }
    }
}