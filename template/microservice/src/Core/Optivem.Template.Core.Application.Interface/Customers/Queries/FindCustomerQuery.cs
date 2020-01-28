using Optivem.Atomiv.Core.Application;
using System;

namespace Optivem.Template.Core.Application.Customers.Queries
{
    public class FindCustomerQuery : IRequest<FindCustomerQueryResponse>
    {
        public Guid Id { get; set; }
    }
}