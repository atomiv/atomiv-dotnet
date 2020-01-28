using Optivem.Atomiv.Core.Application;
using System;

namespace Optivem.Template.Core.Application.Customers.Commands
{
    public class DeleteCustomerCommand : IRequest<DeleteCustomerCommandResponse>
    {
        public Guid Id { get; set; }
    }
}