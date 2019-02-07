using Optivem.Platform.Infrastructure.Common.Mapping.AutoMapper;
using Optivem.Platform.Test.Web.AspNetCore.Rest.Fake.Dtos.Customers;
using Optivem.Platform.Test.Web.AspNetCore.Rest.Fake.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Optivem.Platform.Test.Web.AspNetCore.Rest.Fake.Profiles.Customers
{
    public class CustomerPutResponseProfile : AutoMapperResponseProfile<Customer, CustomerPutResponse>
    {
    }
}
