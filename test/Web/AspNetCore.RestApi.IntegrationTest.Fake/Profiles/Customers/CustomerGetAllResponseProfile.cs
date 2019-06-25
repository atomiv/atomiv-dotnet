using Optivem.Infrastructure.AutoMapper;
using Optivem.Web.AspNetCore.RestApi.IntegrationTest.Fake.Dtos.Customers;
using Optivem.Web.AspNetCore.RestApi.IntegrationTest.Fake.Entities;
using System.Collections.Generic;

namespace Optivem.Web.AspNetCore.RestApi.IntegrationTest.Fake.Profiles.Customers
{
    public class CustomerGetAllResponseProfile : ResponseProfile<IList<Customer>, CustomerGetAllResponse>
    {
    }
}