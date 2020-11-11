using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Atomiv.Core.Domain
{
    public interface IEnumerableValidator<T>
        where T : IValidatable
    {
        Task<ValidationResult> ValidateAsync(IEnumerable<T> enumerable);
    }
}
