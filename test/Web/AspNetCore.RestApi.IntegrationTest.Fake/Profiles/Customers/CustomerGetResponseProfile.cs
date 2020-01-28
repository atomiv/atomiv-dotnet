using AutoMapper;
using Optivem.Atomiv.Web.AspNetCore.RestApi.IntegrationTest.Fake.Entities;
using Optivem.Atomiv.Web.AspNetCore.RestApi.IntegrationTest.Fake.Models;

namespace Optivem.Atomiv.Web.AspNetCore.RestApi.IntegrationTest.Fake.Profiles.Customers
{
    public class CustomerGetResponseProfile : Profile
    {
        public CustomerGetResponseProfile()
        {
            CreateMap<Customer, CustomerGetResponse>();
        }
    }
}