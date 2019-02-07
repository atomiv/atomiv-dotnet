using Optivem.Platform.Infrastructure.Common.Mapping.AutoMapper;
using Optivem.Platform.Test.Web.AspNetCore.Rest.Fake.Entities;
using Optivem.Platform.Test.Web.AspNetCore.Rest.Fake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Optivem.Platform.Test.Web.AspNetCore.Rest.Fake.Profiles.Customers
{
    public class CustomerPutRequestProfile : AutoMapperRequestProfile<CustomerPutRequest, Customer>
    {
    }
}
