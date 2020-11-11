using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Atomiv.Core.Domain
{
    public interface IRule<T> where T : IValidatable
    {
        Task<RuleValidationResult> ValidateAsync(T obj);
    }
}
