using Atomiv.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Atomiv.Template.Core.Domain.Orders.Rules
{
    public class OrderDateMustBeInThePastRule : IRule<Order>
    {
        private readonly ITimeService _timeService;

        public OrderDateMustBeInThePastRule(ITimeService timeService)
        {
            _timeService = timeService;
        }

        public Task<RuleValidationResult> ValidateAsync(Order order)
        {
            var orderDate = order.OrderDate;
            var isInPast = orderDate <= _timeService.Now;

            if(!isInPast)
            {
                return Task.FromResult(RuleValidationResult.Error("Order date must be in the past"));
            }

            return Task.FromResult(RuleValidationResult.Success());
        }
    }
}
