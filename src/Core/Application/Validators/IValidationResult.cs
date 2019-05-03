using System.Collections.Generic;

namespace Optivem.Framework.Core.Application.Ports.Out.Validators
{
    public interface IValidationResult
    {
        bool IsValid { get; }

        IList<IValidationError> Errors { get; }
    }
}
