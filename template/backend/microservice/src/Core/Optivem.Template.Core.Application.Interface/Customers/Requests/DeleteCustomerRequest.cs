using Optivem.Framework.Core.Application;
using System;

namespace Optivem.Template.Core.Application.Customers.Requests
{
    public class DeleteCustomerRequest : IRequest<VoidResponse>
    {
        public Guid Id { get; set; }
    }
}