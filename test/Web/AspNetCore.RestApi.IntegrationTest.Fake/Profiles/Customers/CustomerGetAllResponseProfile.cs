using AutoMapper;
using Optivem.Atomiv.Web.AspNetCore.RestApi.IntegrationTest.Fake.Dtos.Customers;
using Optivem.Atomiv.Web.AspNetCore.RestApi.IntegrationTest.Fake.Entities;
using System.Collections.Generic;

namespace Optivem.Atomiv.Web.AspNetCore.RestApi.IntegrationTest.Fake.Profiles.Customers
{
    public class CustomerGetAllResponseProfile : Profile
    {
        public CustomerGetAllResponseProfile()
        {
            CreateMap<IList<Customer>, CustomerGetAllResponse>();
        }
    }
}