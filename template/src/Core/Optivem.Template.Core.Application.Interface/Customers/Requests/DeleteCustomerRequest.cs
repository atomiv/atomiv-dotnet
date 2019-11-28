using Optivem.Framework.Core.Common;
using Optivem.Template.Core.Application.Customers.Responses;
using System;

namespace Optivem.Template.Core.Application.Customers.Requests
{
    public class DeleteCustomerRequest : IRequest<DeleteCustomerResponse>
    {
        public Guid Id { get; set; }
    }
}