using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Atomiv.Core.Domain
{
    public class Validator<TEntity> : IValidator<TEntity>
    {
        private readonly IEnumerable<IRule<TEntity>> _rules;

        public Validator(IEnumerable<IRule<TEntity>> rules)
        {
            _rules = rules;
        }

        public async Task<IEnumerable<ValidationResult>> ValidateAsync(TEntity entity)
        {
            var results = new List<ValidationResult>();

            // TODO: VC: Parallelization

            foreach(var rule in _rules)
            {
                var result = await rule.ValidateAsync(entity);
                results.Add(result);
            }

            return results;
        }
    }
}
