using AutoMapper;
using Optivem.Infrastructure.Mapping.AutoMapper;
using Optivem.NorthwindLite.Core.Application.Interface.Customers.Commands;
using Optivem.NorthwindLite.Core.Domain.Entities;
using Optivem.NorthwindLite.Core.Domain.Identities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.NorthwindLite.Infrastructure.Mapping.Customers
{
    // TODO: VC: should not construct this, but instead just apply update... therefore auto mapping is not needed, but as private methods instead

    public class UpdateCustomerRequestProfile : RequestProfile<UpdateCustomerRequest, Customer>
    {
        protected override void Extend(IMappingExpression<UpdateCustomerRequest, Customer> map)
        {
            map.ConstructUsing(e => new Customer(CustomerIdentity.Null, e.FirstName, e.LastName));
        }
    }
}
