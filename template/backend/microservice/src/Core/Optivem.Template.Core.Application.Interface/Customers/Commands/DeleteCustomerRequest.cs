using Optivem.Framework.Core.Application;
using System;

namespace Optivem.Template.Core.Application.Customers.Commands
{
    public class DeleteCustomerRequest : IRequest<DeleteCustomerResponse>
    {
        public Guid Id { get; set; }
    }
}