using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Atomiv.Core.Domain
{
    public class EnumerableValidator<T> : IEnumerableValidator<T>
        where T : IValidatable
    {
        private readonly IValidator<T> _validator;

        public EnumerableValidator(IValidator<T> validator)
        {
            _validator = validator;
        }

        public async Task<ValidationResult> ValidateAsync(IEnumerable<T> enumerable)
        {
            var ruleValidationResults = new List<RuleValidationResult>();

            // TODO: VC: Consider parallelization
            // TODO: VC: Consider case of stop on error

            foreach (var obj in enumerable)
            {
                var validationResult = await _validator.ValidateAsync(obj);
                ruleValidationResults.AddRange(validationResult.RuleResults);
            }

            return new ValidationResult(ruleValidationResults);
        }
    }
}
