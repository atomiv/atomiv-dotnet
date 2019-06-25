using Optivem.Infrastructure.AutoMapper;
using Optivem.Web.AspNetCore.RestApi.Fake.Dtos.Customers;
using Optivem.Web.AspNetCore.RestApi.Fake.Entities;
using System.Collections.Generic;

namespace Optivem.Web.AspNetCore.RestApi.Fake.Profiles.Customers
{
    public class CustomerGetAllResponseProfile : ResponseProfile<IList<Customer>, CustomerGetAllResponse>
    {
    }
}