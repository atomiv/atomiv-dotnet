using Optivem.Infrastructure.AutoMapper;
using Optivem.Web.AspNetCore.Fake.Dtos.Customers;
using Optivem.Web.AspNetCore.Fake.Entities;
using System.Collections.Generic;

namespace Optivem.Web.AspNetCore.Fake.Profiles.Customers
{
    public class CustomerGetAllResponseProfile : ResponseProfile<IList<Customer>, CustomerGetAllResponse>
    {
    }
}