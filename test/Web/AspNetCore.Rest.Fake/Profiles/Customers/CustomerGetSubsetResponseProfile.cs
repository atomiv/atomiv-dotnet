using Optivem.Infrastructure.Mapping.AutoMapper;
using Optivem.Web.AspNetCore.Fake.Entities;
using Optivem.Web.AspNetCore.Rest.Fake.Dtos.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Optivem.Web.AspNetCore.Rest.Fake.Profiles.Customers
{
    public class CustomerGetSubsetResponseProfile : AutoMapperResponseProfile<Customer, CustomerGetSubsetResponse>
    {
    }
}
