using System.Collections.Generic;

namespace Optivem.Framework.Core.Application
{
    public interface IRequestValidationResult
    {
        bool IsValid { get; }

        IList<IRequestValidationError> Errors { get; }
    }
}