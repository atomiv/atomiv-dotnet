using Optivem.Framework.Core.Application;
using Optivem.Template.Core.Application.Customers.Responses;
using System;

namespace Optivem.Template.Core.Application.Customers.Requests
{
    public class FindCustomerRequest : IRequest<FindCustomerResponse>
    {
        public Guid Id { get; set; }
    }
}