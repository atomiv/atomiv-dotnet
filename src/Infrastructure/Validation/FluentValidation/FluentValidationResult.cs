using FluentValidation.Results;
using Optivem.Core.Application;
using System.Collections.Generic;
using System.Linq;

namespace Optivem.Framework.Infrastructure.Application.Validators.FluentValidation
{
    public class FluentValidationResult : IValidationResult
    {
        private ValidationResult _result;

        public FluentValidationResult(ValidationResult result)
        {
            _result = result;
        }

        public bool IsValid => _result.IsValid;

        public IList<IValidationError> Errors => _result.Errors.Select(GetValidationError).ToList();

        private static IValidationError GetValidationError(ValidationFailure failure)
        {
            return new FluentValidationError(failure);
        }
    }
}
