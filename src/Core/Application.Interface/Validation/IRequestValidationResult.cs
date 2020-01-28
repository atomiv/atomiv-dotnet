using System.Collections.Generic;

namespace Optivem.Atomiv.Core.Application
{
    public interface IRequestValidationResult
    {
        bool IsValid { get; }

        IEnumerable<IRequestValidationError> Errors { get; }
    }
}