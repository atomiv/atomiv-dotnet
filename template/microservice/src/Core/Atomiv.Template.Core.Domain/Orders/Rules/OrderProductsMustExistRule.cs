using Atomiv.Core.Domain;
using Atomiv.Template.Core.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atomiv.Template.Core.Domain.Orders.Rules
{
    public class OrderProductsMustExistRule : IRule<Order>
    {
        private readonly IProductReadonlyRepository _productReadonlyRepository;

        public OrderProductsMustExistRule(IProductReadonlyRepository productReadonlyRepository)
        {
            _productReadonlyRepository = productReadonlyRepository;
        }

        public async Task<RuleValidationResult> ValidateAsync(Order order)
        {
            var productIds = order.OrderItems
                .Select(e => e.ProductId)
                .Distinct();

            var products = await _productReadonlyRepository.FindReadonlyAsync(productIds);

            if (productIds.Count() != products.Count())
            {
                return RuleValidationResult.Error("Some products don't exist");
            }

            return RuleValidationResult.Success();
        }
    }
}
