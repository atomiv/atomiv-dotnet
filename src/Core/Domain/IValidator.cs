using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Atomiv.Core.Domain
{
    public interface IValidator<TEntity>
    {
        Task<IEnumerable<ValidationResult>> ValidateAsync(TEntity entity);
    }
}
