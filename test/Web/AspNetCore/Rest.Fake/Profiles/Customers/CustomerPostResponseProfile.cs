using Optivem.Framework.Infrastructure.Application.Mappers.AutoMapper;
using Optivem.Framework.Web.AspNetCore.Rest.Fake.Dtos.Customers;
using Optivem.Framework.Web.AspNetCore.Rest.Fake.Entities;

namespace Optivem.Framework.Web.AspNetCore.Rest.Fake.Profiles.Customers
{
    public class CustomerPostResponseProfile : AutoMapperResponseProfile<Customer, CustomerPostResponse>
    {
    }
}
