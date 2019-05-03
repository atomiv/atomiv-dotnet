using System.Collections.Generic;

namespace Optivem.Framework.Core.Application.Validators
{
    public interface IValidationResult
    {
        bool IsValid { get; }

        IList<IValidationError> Errors { get; }
    }
}
