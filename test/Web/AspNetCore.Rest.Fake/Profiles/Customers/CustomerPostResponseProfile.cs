using Optivem.Framework.Web.AspNetCore.Rest.Fake.Dtos.Customers;
using Optivem.Framework.Web.AspNetCore.Rest.Fake.Entities;
using Optivem.Infrastructure.AutoMapper;

namespace Optivem.Framework.Web.AspNetCore.Rest.Fake.Profiles.Customers
{
    public class CustomerPostResponseProfile : AutoMapperResponseProfile<Customer, CustomerPostResponse>
    {
    }
}
