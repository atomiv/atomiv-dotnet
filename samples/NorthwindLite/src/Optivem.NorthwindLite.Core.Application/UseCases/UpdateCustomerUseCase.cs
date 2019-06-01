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
    // TODO: VC: Perhaps have shared responses?

    public class UpdateCustomerUseCase : UpdateAggregateUseCase<UpdateCustomerRequest, UpdateCustomerResponse, Customer, CustomerIdentity, int>
    {
        public UpdateCustomerUseCase(IResponseMapper responseMapper, IUnitOfWork unitOfWork, ICrudRepository<Customer, CustomerIdentity> repository) 
            : base(responseMapper, unitOfWork, repository)
        {
        }

        protected override CustomerIdentity GetIdentity(int id)
        {
            return new CustomerIdentity(id);
        }

        protected override void Update(Customer aggregateRoot, UpdateCustomerRequest request)
        {
            aggregateRoot.FirstName = request.FirstName;
            aggregateRoot.LastName = request.LastName;
        }
    }
}
