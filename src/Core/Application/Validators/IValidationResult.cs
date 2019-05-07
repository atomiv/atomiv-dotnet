using System.Collections.Generic;

namespace Optivem.Core.Application.Validators
{
    public interface IValidationResult
    {
        bool IsValid { get; }

        IList<IValidationError> Errors { get; }
    }
}
