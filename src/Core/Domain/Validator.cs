using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Atomiv.Core.Domain
{
    public class Validator<T> : IValidator<T>
        where T : IValidatable
    {
        private readonly IEnumerable<IRule<T>> _rules;

        public Validator(IEnumerable<IRule<T>> rules)
        {
            _rules = rules;
        }

        public async Task<ValidationResult> ValidateAsync(T entity)
        {
            var ruleResults = new List<RuleValidationResult>();

            // TODO: VC: Parallelization

            foreach(var rule in _rules)
            {
                var ruleResult = await rule.ValidateAsync(entity);
                ruleResults.Add(ruleResult);
            }

            return new ValidationResult(ruleResults);
        }
    }
}
