using Optivem.Framework.Core.Application;
using System;

namespace Optivem.Template.Core.Application.Customers.Queries
{
    public class FindCustomerRequest : IRequest<FindCustomerResponse>
    {
        public Guid Id { get; set; }
    }
}