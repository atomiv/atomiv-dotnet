using Optivem.Platform.Infrastructure.Common.Mapping.AutoMapper;
using Optivem.Platform.Web.AspNetCore.Rest.Fake.Entities;
using Optivem.Platform.Web.AspNetCore.Rest.Fake.Models;

namespace Optivem.Platform.Web.AspNetCore.Rest.Fake.Profiles.Customers
{
    public class CustomerPutRequestProfile : AutoMapperRequestProfile<CustomerPutRequest, Customer>
    {
    }
}
