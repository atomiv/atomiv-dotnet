using Optivem.Framework.Core.Common;
using Optivem.Template.Core.Application.Customers.Responses;
using System;

namespace Optivem.Template.Core.Application.Customers.Requests
{
    public class UpdateCustomerRequest : IRequest<UpdateCustomerResponse>
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}