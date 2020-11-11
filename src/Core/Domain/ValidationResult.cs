using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atomiv.Core.Domain
{
    public class ValidationResult
    {
        public ValidationResult(IEnumerable<RuleValidationResult> ruleResults)
        {
            RuleResults = ruleResults;
        }

        public IEnumerable<RuleValidationResult> RuleResults { get; }

        public bool IsValid => RuleResults.All(e => e.IsValid);

        public static ValidationResult Success()
        {
            return new ValidationResult(new List<RuleValidationResult>());
        }
    }
}
