using System;
using System.Collections.Generic;
using System.Text;

namespace Atomiv.Core.Domain
{
    public class ValidationResult
    {
        public ValidationResult(bool isValid, string errorMessage)
        {
            IsValid = isValid;
            ErrorMessage = errorMessage;
        }

        public bool IsValid { get; }

        public string ErrorMessage { get; }

        public static ValidationResult Error(string errorMessage)
        {
            return new ValidationResult(false, errorMessage);
        }

        public static ValidationResult Success()
        {
            return new ValidationResult(true, null);
        }
    }
}
