using System;
using System.Collections.Generic;
using System.Text;

namespace Atomiv.Core.Domain
{
    public class RuleValidationResult
    {
        public RuleValidationResult(bool isValid, string errorMessage)
        {
            IsValid = isValid;
            ErrorMessage = errorMessage;
        }

        public bool IsValid { get; }

        public string ErrorMessage { get; }

        public static RuleValidationResult Error(string errorMessage)
        {
            return new RuleValidationResult(false, errorMessage);
        }

        public static RuleValidationResult Success()
        {
            return new RuleValidationResult(true, null);
        }
    }
}
