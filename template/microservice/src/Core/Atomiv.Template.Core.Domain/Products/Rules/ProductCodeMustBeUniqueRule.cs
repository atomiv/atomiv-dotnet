using Atomiv.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Atomiv.Template.Core.Domain.Products.Rules
{
    public class ProductCodeMustBeUniqueRule : IRule<Product>
    {
        private readonly IProductReadonlyRepository _productReadonlyRepository;

        public ProductCodeMustBeUniqueRule(IProductReadonlyRepository productReadonlyRepository)
        {
            _productReadonlyRepository = productReadonlyRepository;
        }

        public async Task<RuleValidationResult> ValidateAsync(Product product)
        {
            var productCode = product.ProductCode;

            var exists = await _productReadonlyRepository.ExistsAsync(productCode);

            if(exists)
            {
                return RuleValidationResult.Error($"Product code {productCode} already exists.");
            }

            return RuleValidationResult.Success();
        }
    }
}
