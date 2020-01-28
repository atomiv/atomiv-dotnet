using Optivem.Atomiv.Core.Application;
using System;

namespace Optivem.Atomiv.Template.Core.Application.Customers.Queries
{
    public class FindCustomerQuery : IRequest<FindCustomerQueryResponse>
    {
        public Guid Id { get; set; }
    }
}