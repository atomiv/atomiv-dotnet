using Optivem.Core.Application;
using Optivem.Core.Domain;
using Optivem.NorthwindLite.Core.Application.Interface.Customers.Commands;
using Optivem.NorthwindLite.Core.Domain.Entities;
using Optivem.NorthwindLite.Core.Domain.Identities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.NorthwindLite.Core.Application.UseCases
{
    public class DeleteCustomerUseCase : DeleteAggregateCase<DeleteCustomerRequest, DeleteCustomerResponse, Customer, CustomerIdentity, int>
    {
        public DeleteCustomerUseCase(IUnitOfWork unitOfWork, ICrudRepository<Customer, CustomerIdentity> repository) 
            : base(unitOfWork, repository)
        {
        }

        protected override CustomerIdentity GetIdentity(int id)
        {
            return new CustomerIdentity(id);
        }
    }
}
