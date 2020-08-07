using Atomiv.Core.Application;
using System;

namespace Atomiv.Template.Core.Application.Commands.Customers
{
    public class DeleteCustomerCommand : ICommand<DeleteCustomerCommandResponse>
    {
        public Guid Id { get; set; }
    }
}