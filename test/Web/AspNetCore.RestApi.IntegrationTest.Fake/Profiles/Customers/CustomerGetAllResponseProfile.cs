using AutoMapper;
using Atomiv.Web.AspNetCore.RestApi.IntegrationTest.Fake.Dtos.Customers;
using Atomiv.Web.AspNetCore.RestApi.IntegrationTest.Fake.Entities;
using System.Collections.Generic;

namespace Atomiv.Web.AspNetCore.RestApi.IntegrationTest.Fake.Profiles.Customers
{
    public class CustomerGetAllResponseProfile : Profile
    {
        public CustomerGetAllResponseProfile()
        {
            CreateMap<IList<Customer>, CustomerGetAllResponse>();
        }
    }
}