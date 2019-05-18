using Optivem.Web.AspNetCore.Fake.Dtos.Customers;
using Optivem.Web.AspNetCore.Fake.Entities;
using Optivem.Infrastructure.Mapping.AutoMapper;

namespace Optivem.Web.AspNetCore.Fake.Profiles.Customers
{
    public class CustomerGetAllResponseProfile : AutoMapperResponseProfile<Customer, CustomerGetAllResponse>
    {
    }
}
