using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Atomiv.Core.Domain
{
    public interface IValidator<T>
        where T : IValidatable
    {
        Task<ValidationResult> ValidateAsync(T obj);
    }

    public interface IValidator
    {
        Task<ValidationResult> ValidateAsync<T>(T obj) where T : IValidatable;
    }
}
