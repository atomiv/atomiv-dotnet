﻿using Optivem.Framework.Infrastructure.AutoMapper;
using Optivem.Framework.Web.AspNetCore.RestApi.IntegrationTest.Fake.Dtos.Customers;
using Optivem.Framework.Web.AspNetCore.RestApi.IntegrationTest.Fake.Entities;
using System.Collections.Generic;

namespace Optivem.Framework.Web.AspNetCore.RestApi.IntegrationTest.Fake.Profiles.Customers
{
    public class CustomerGetAllResponseProfile : ResponseProfile<IList<Customer>, CustomerGetAllResponse>
    {
    }
}