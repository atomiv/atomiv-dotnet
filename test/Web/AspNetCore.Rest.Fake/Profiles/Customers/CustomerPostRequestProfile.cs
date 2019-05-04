using Optivem.Framework.Web.AspNetCore.Rest.Fake.Entities;
using Optivem.Framework.Web.AspNetCore.Rest.Fake.Models;
using Optivem.Infrastructure.Mapping.AutoMapper;

namespace Optivem.Framework.Web.AspNetCore.Rest.Fake.Profiles.Customers
{
    public class CustomerPostRequestProfile : AutoMapperRequestProfile<CustomerPostRequest, Customer>
    {
    }
}
