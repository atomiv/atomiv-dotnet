using System.Collections.Generic;

namespace Optivem.Core.Application
{
    public interface IValidationResult
    {
        bool IsValid { get; }

        IList<IValidationError> Errors { get; }
    }
}