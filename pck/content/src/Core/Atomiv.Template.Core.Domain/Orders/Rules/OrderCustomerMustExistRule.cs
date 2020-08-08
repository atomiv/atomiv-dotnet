using Atomiv.Core.Domain;
using Atomiv.Template.Core.Common;
using Atomiv.Template.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Atomiv.Template.Core.Domain.Orders.Rules
{
    public class OrderCustomerMustExistRule : IRule<Order>
    {
        private readonly ICustomerReadonlyRepository _customerReadonlyRepository;

        public OrderCustomerMustExistRule(ICustomerReadonlyRepository customerReadonlyRepository)
        {
            _customerReadonlyRepository = customerReadonlyRepository;
        }

        public async Task<RuleValidationResult> ValidateAsync(Order order)
        {
            var customerId = order.CustomerId;

            var existsCustomer = await _customerReadonlyRepository.ExistsAsync(customerId);

            if (!existsCustomer)
            {
                return RuleValidationResult.Error($"Customer {customerId} does not exist");
            }

            return RuleValidationResult.Success();
        }
    }
}
